    var orders = _uow.Orders.GetAll()
        .Where(x => x.Created > baselineDate)
        // this will group by the whole date. If you only want to group by part of the date,
        // (e. g. day or day, month), you could group by x => x.Date.Month or the like
        .GroupBy(x => x.Date)
        // if you're using EF or Linq-to-SQL, you'll likely need to read the date values into memory
        // and then call ToArray before converting to a string
        .Select(g => new {
            // or use just "MMM" for just the month
            DateStrings = g.Select(g => g.Key.ToString("MMM d")).ToArray(),
            Total = ...
        });
