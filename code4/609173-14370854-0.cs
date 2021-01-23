        string path = @"C:\\CSV.txt";
        string[] lines = File.ReadAllLines(path);
        for (int i = 0; i < lines.Length; i++)
		{
            string line = lines[i];
            if (line.Contains(","))
            {
                var split = line.Split(',');
                if (split[1].Contains("34"))
                {
                    split[1] = "100";
                    line = string.Join(",", split);
                }
            }
        }
        File.WriteAllLines(@"C:\\CSV.txt", lines);
