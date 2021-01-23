    void Main()
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        int max = DateTime.Today.AddYears(1).Subtract(DateTime.Today).Days;
        for (int man=0;man<40;man++)
        {
            for (int x = 0; x <= max; x++)
            {
                //do stuff
            }
        }
        sw.Stop();
        Console.WriteLine(sw.Elapsed.TotalMilliseconds);
        sw.Reset();
        sw.Start();
        for (int man=0;man<40;man++)
        {
            for (DateTime date = DateTime.Now.Date;date<DateTime.Now.AddYears(1);date=date.AddDays(1))
            {
                //do stuff
            }
        }
        sw.Stop();
        Console.WriteLine(sw.Elapsed.TotalMilliseconds);
     
    }
    
