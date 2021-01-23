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
 
       var elapsedTime = results.SelectMany(line => line.ToLower().Split(' '))
                         .Where(line => line.StartsWith("time"))
                         .Select(timeLine => decimal.Parse(timeLine.Split(':')[1].Replace("ms",String.Empty)))
                         .Sum( time => time);
