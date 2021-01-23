    List<DateTime> months = new List<DateTime>();
    for (int i = 0; i < DateTime.Now.Month; ++i)
    {
         months.Add(new DateTime(DateTime.Now.Year, i, 1));
    }
