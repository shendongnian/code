    DateTime lastDate = new DateTime(2012, 1, 1);
    List<DateTime> list = new List<DateTime>();
    while (lastDate < (DateTime.Today.AddMonths(-1)))
    {
      lastDate = lastDate.AddMonths(1);
      list.Add(lastDate);
    }
