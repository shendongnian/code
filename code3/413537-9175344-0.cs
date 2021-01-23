    DateTime previousDay = new DateTime(year, month, day);
    string test1 = previousDay.ToString();
    previousDay = previousDay.Subtract(new TimeSpan(1, 0, 0, 0));
    string test2 = previousDay.ToString();
    previousDay = previousDay.Subtract(new TimeSpan(1, 0, 0, 0));
    string test3 = previousDay.ToString();
