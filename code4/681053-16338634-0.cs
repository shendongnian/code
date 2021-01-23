    DateTime endDate = new DateTime(2013, 12, 31);
    List<string> list = new List<string>();
    for (DateTime startDate = new DateTime(2013, 1, 1); startDate.Month <= endDate.Month; startDate = startDate.AddMonths(1))
    {
        list.Add(startDate.ToString("MMMM, yyyy"));
        if (startDate.Month == endDate.Month)
            break;
    }
