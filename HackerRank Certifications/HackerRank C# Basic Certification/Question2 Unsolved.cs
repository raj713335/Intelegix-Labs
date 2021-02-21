using System;
using System.Collections.Generic;
using System.IO;

namespace Solution
{

    public class NotesStore
    {

        public List<string> data = new List<string>();
        public NotesStore() { }
        public void AddNote(String state, String name)
        {
            if (name == "" || name ==null)
            {
                throw new ArgumentException("Name Cannot be empty");
            }
            if (state != "active" || state != "completed" || state != "others")
            {
                throw new ArgumentException("Invalid state {0}", state);
            }
            data.Add(name);


        }
        public List<String> GetNotes(String state) 
        {
            if (state != "active" || state != "completed" || state != "others")
            {
                throw new ArgumentException("Invalid state {0}", state);
            }
            else
            {
                return data;
            }
        }
    }

    public class Solution2
    {
        public static void Main()
        {
            var notesStoreObj = new NotesStore();
            var n = int.Parse(Console.ReadLine());
            for (var i = 0; i < n; i++)
            {
                var operationInfo = Console.ReadLine().Split(' ');
                try
                {
                    if (operationInfo[0] == "AddNote")
                        notesStoreObj.AddNote(operationInfo[1], operationInfo.Length == 2 ? "" : operationInfo[2]);
                    else if (operationInfo[0] == "GetNotes")
                    {
                        var result = notesStoreObj.GetNotes(operationInfo[1]);
                        if (result.Count == 0)
                            Console.WriteLine("No Notes");
                        else
                            Console.WriteLine(string.Join(",", result));
                    }
                    else
                    {
                        Console.WriteLine("Invalid Parameter");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
        }
    }
}
