    public IEnumerable<DateTime> Dates(int nDays)
    {
        DateTime dt = DateTime.Now;
        yield return dt;
        for(int i=0;i<nDays-1;i++)
        {
            dt = dt.AddDays(-1);
            yield return  dt;
        }
    }
    foreach (var dt in Dates(10))
    {
         Console.WriteLine(dt.ToString("MM-dd-yyyy"));
    }
