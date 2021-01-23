    string fileName = @"C:\Users\karan\Desktop\Sample log file.txt";
                string[] textLines = File.ReadAllLines(fileName);
    
                List<string> results = new List<string>();
    
                foreach (string line in textLines)
                {
                    if (line.Contains(searchKeyword))
                    {
                        results.Add(line);
                    }
                }
