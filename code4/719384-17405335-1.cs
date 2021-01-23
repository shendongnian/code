    var date = ...;
    var events = Enumerable.Range(1, DateTime.DaysInMonth(date.Year, date.Month))
        .ToDictionary(
            day => new DateTime(date.Year, date.Month, day),
            day => new List<Event>());
