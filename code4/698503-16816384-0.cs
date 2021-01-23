    DateTime start = new DateTime(2013, 5, 29, 0, 9, 0);
    DateTime end = new DateTime(2013, 5, 29, 15, 0, 0);
    TimeSpan interval = new TimeSpan(0, 20, 0 0); // 20 minutes
    for (DateTime temp = start; temp < end; temp = temp.Add(interval))
    {
        // Here you output temp, such as:
        Console.WriteLine (temp.ToShortTimeString() + " - " + temp.Add(interval).ToShortTimeString());
    }
