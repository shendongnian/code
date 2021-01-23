    private static IEnumerable<List<double>> ProcessRawNumbers2(IEnumerable<string> lines)
    {
            var numbers = new List<List<double>>();
            foreach(var line in lines)
            {
                lock (numbers)
                {
                    numbers.Add(ProcessLine(line));
                }
            }
        return numbers;
    }
