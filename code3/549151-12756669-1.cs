    string line;
    List<long[]> list = new List<long[]>();
    using (StreamReader file = new StreamReader(@"..\..\Histograms.txt"))
    {
        do { line = file.ReadLine(); } while (!line.Trim().Equals("DATA:"));                               
        while ((line = file.ReadLine()) != null)
        {
            long[] valArray = new long[256];
            var split = line.Split(new char[] { ':' });
            if (split.Length == 2)
            {
                var valArrayStr = split[1].Split(new char[] { ',' });
                for (int i = 0; i < valArrayStr.Length; i++)
                {
                    int result;
                    if (int.TryParse(valArrayStr[i].Trim(), out result))
                        valArray[i] = result;
                }
            }
            list.Add(valArray);
        }
    }
