    List<DateTime> sixFridays = new List<DateTime>();
    DateTime foo = DateTime.Today;
    while (foo.DayOfWeek != DayOfWeek.Friday) {
        foo = foo.AddDays(-1);
    }
    for (int i = 0; i < 6; foo.AddDays(-7)) {
        sixFridays.Add(foo);
        i++; // I don't remember if you could place this together with foo.AddDays(-7) in the last part of the command.
    }
