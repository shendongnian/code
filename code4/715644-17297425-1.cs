    List<DateTime> sixFridays = new List<DateTime>();
    DateTime foo = DateTime.Today;
    while (sixFridays.Count < 6) {
        if (foo.DayOfWeek == DayOfWeek.Friday) sixFridays.Add(foo);
        foo = foo.AddDays(-1);
    }
