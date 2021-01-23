    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    
    namespace DynamicallyDetectFixedWithDelimiter
    {
        class Program
        {
            static void Main(string[] args)
            {
                var sr = new StreamReader(@"C:\Temp\test.txt");
    
                // Get initial list of delimiters
                char[] firstLine = sr.ReadLine().ToCharArray();
                Dictionary<int, char> delimiters = new Dictionary<int, char>();
                for (int i = 0; i < firstLine.Count(); i++)
                {
                    delimiters.Add(i, firstLine[i]);
                }
    
                // Read subsequent lines, remove delimeters from 
                // the dictionary that are not present in subsequent lines
                string line;
                while ((line = sr.ReadLine()) != null && delimiters.Count() != 0)
                {
                    var subsequentLine = line.ToCharArray();
                    var invalidDelimiters = new List<int>();
    
                    // Compare all chars in first and subsequent line
                    foreach (var delimiter in delimiters)
                    {
                        if (delimiter.Key >= subsequentLine.Count())
                        {
                            invalidDelimiters.Add(delimiter.Key);
                            continue;
                        }
    
                        // Remove delimiter when it differs from the 
                        // character at the same position in a subsequent line
                        if (subsequentLine[delimiter.Key] != delimiter.Value)
                        {
                            invalidDelimiters.Add(delimiter.Key);
                        }
                    }
                    foreach (var invalidDelimiter in invalidDelimiters)
                    {
                        delimiters.Remove(invalidDelimiter);
                    }
                }
    
                foreach (var delimiter in delimiters)
                {
                    Console.WriteLine(String.Format("Delimiter at {0} = {1}", delimiter.Key, delimiter.Value));
                }
    
                sr.Close();
            }
        }
    }
