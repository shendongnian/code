    var orders =
        from month in Enumerable.Range(0, 7)
            .Select(i => new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(i))
        join ord in db.Items
            on month equals new DateTime(ord.Expiry.Value.Year, ord.Expiry.Value.Month, 1)
            into ords
        select new { month.Month, Quantity = ords.Count() };
