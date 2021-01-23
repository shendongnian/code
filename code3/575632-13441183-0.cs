    DateTime StartDate = DateTime.Now.Date;
    DateTime EndDate = DateTime.Now.Date.AddMonths(13);
    IEnumerable<double> daysToAdd = Enumerable.Range(0,
                                                    (EndDate - StartDate).Days + 1)
                                                .ToList().ConvertAll(d => (double)d);
    IEnumerable<DateTime> ListOfDates = daysToAdd.Select(StartDate.AddDays).ToList();
