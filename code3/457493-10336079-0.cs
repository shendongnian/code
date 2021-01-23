    double result = 0;
    List<DateTime> list = new List<DateTime>();
    list.Add(new DateTime(123456));
    TimeSpan ts = DateTime.Now - list[list.Count - 1];
    result = ts.TotalSeconds;
