    var query = Bookings.GroupBy(book => new GroupedLine()
    {
        Group = book.Group,
        Type = book.Type,
        Status = book.Status
    })
    .Select(group => new
    {
        Line = group.Key,
        Dates = group.GroupBy(book => GetWeekOfYear(book.Date))
            .Select(innerGroup => new
            {
                Week = innerGroup.Key,
                Count = innerGroup.Count(),
                TotalPrice = innerGroup.Sum(book => book.Price)
            })
    });
    public static int GetWeekOfYear(DateTime date)
    {
        return date.DayOfYear % 7;
    }
