    // TODO: Consider what time zone you want to consider the current date in
    var today = DateTime.Today;
    var start = new DateTime(today.Year, today.Month, 1);
    var end = start.AddMonths(1); // Exclusive end-point
    var query = orders.Where(o => o.DateOfPayment.Value >= start &&
                                  o.DateOfPayment.Value < end)
                            .Sum(o => o.Total)
