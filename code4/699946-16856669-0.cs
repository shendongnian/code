    for (Int32 i = -24; i <= 23; i++)
    {
        DateTime dt = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.AddHours(i).Day, DateTime.Now.AddHours(i).Hour, DateTime.Now.AddHours(i).Minute, DateTime.Now.AddHours(i).Second);
        Console.writeLine(dt.ToString());
    }
