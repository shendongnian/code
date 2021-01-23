    String path = @"C:\CSV.txt";
    List<String> lines = new List<String>();
    if (File.Exists(path));
    {
        using (StreamReader reader = new StreamReader(path))
        {
            String line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains(","))
                {
                    String[] split = line.Split(',');
                    
                    if (split[1].Contains("34"))
                    {
                        split[1] = "100";
                        line = string.Join(",", split);
                    }
                }
                list.Add(line);
            }
        }
    }
