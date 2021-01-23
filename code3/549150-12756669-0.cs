    string line;
    using (StreamReader file = new StreamReader("Histograms.txt"))
    {
        do { line = file.ReadLine(); } while (line.Trim().Equals("DATA:"));
        List<long[]> list = new List<long[]>();
        while ((line = file.ReadLine()) != null)
        {
            long[] valArray = new long[256];
            var split = line.Split(":");
            if (split.Length == 2)
            {
                var valArrayStr = split[1].Split(",");
                for (int i = 0; i < valArrayStr.Length; i++)
                {
                    var result;
                    if (int.TryParse(valArrayStr[i].Trim(), out result))
                        valArray[i] = result;
                }
            }
            list.Add(valArray);
        }
    }
