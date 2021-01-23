    var firstDaysOfMonths = Enumerable.Range(0, 7).Select(i =>
        new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(i));
    var orders = firstDaysOfMonths.GroupJoin(
        db.Items,
        fd => fd,
        ord => new DateTime(ord.Expiry.Value.Year, ord.Expiry.Value.Month, 1),
        (fd, ords) => new { Month = fd.Month, Quantity = ords.Count() });
