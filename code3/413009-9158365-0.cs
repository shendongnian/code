    var results = yourList.GroupBy(x => GetFirstDayOfWeek(x.Date))
                          .ToDictionary(g => g.Key, g => g.Sum(x => x.Value));
    // ...
    private static DateTime GetFirstDayOfWeek(DateTime dt)
    {
        // left as an exercise for the reader!
    }
