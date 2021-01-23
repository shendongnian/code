    var startDate = new DateTime(2013, 1, 25);
    var endDate = new DateTime(2013, 1, 31);
    int days = (endDate - startDate).Days + 1; // incl. endDate 
    List<DateTime> range = Enumerable.Range(0, days)
        .Select(i => startDate.AddDays(i))
        .ToList();
