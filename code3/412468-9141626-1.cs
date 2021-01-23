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
                string nameLine = file.ReadLine();
                string valueLine = file.ReadLine();
    
    
                file.Close();
    
                string[] varNames = nameLine.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                string[] varValues = valueLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Dictionary<string, object> map = new Dictionary<string, object>();
    
                for(int i = 0; i<varNames.Length; i++)
                {
                    try
                    {
                        map[varNames[i]] = varValues[i];
                    }
                    catch (Exception ex)
                    {
                        map[varNames[i]] = null;
                    }
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
