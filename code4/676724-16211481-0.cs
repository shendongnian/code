    String[] lines = File.ReadAllLines(...);
    foreach(String line in lines)
    {
       String parts[] = line.Split(",", StringSplitOptions.IgnoreEmpty);
       double gx1 = Double.Parse(parts[5]);
       double gx2 = Double.Parse(parts[6]);
    }
