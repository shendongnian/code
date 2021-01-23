    public int TotalLines(string date)
    {
        using (StreamReader r = new StreamReader(date))
        {
            int i = 0;
            while (r.ReadLine() != null) { i++; }
            return i;
        }     
    }
