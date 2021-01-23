        Regex regex = new Regex(@"Elapsed Time:\s*(?<value>\d+\.?\d*)\s*ms");
        double totalTime = 0;
        foreach (Match match in textLines.Select(line => regex.Match(line)).Where(match => match.Captures.Count > 0))
        {
            try
            {
                double time = Double.Parse(match.Groups["value"].Value);
                totalTime += time;
            }
            catch (Exception)
            {
                // not a number
            }
            
        }
