    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using System.Collections;
    
    namespace stringsAsObjects
    {
    
        class stringObject
        {
            public static int Main(string[] args)
            {
                int counter = 0;
                string line;
    
                // Read the file and display it line by line.
                System.IO.StreamReader file =
                   new System.IO.StreamReader("Data.txt");
                line = file.ReadLine();
    
                file.Close();
    
                string[] varNames = line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                Dictionary<string, object> map = new Dictionary<string, object>();
    
                foreach (string name in varNames)
                {
                    map[name] = new object();
                }
    
                foreach (object de in map)
                {
                    System.Console.WriteLine(de);
                }
                
                Console.ReadKey();
                return 0;
    
            }
    
        }
    }
