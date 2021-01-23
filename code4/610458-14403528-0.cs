    List<Types> list = new List<Types>();
    String[] lines = File.ReadAllLines(filePath);
    foreach (String line in lines)
    {
        String[] split = line.Split(new Char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
        
        Types t = new Types();
        t.nbr = (split.Length > 0) ? Convert.ToInt64(split[0].Trim()) : 0;
        t.addr = (split.Length > 3) ? ((split[1].Trim().Length > 1) ? split[3] : String.Empty) : String.Empty;
        list.Add(t);
    }
