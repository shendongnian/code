    Regex regex = new Regex(@"Elapsed Time:\s*(?<value>\d+\.?\d*)\s*ms");
    double totalTime = 0;
    int count = 0;
    foreach (string line in textLines)
    {
        if (line.Contains(searchKeyword))
        {
            Match match = regex.Match(line);
            if (match.Captures.Count > 0)
            {
                try
                {
                    count++;
                    double time = Double.Parse(match.Groups["value"].Value);
                    totalTime += time;
                }
                catch (Exception)
                {
                    // not a number
                }
            }
        }
    }
    double average = totalTime/count;
