    .GroupBy(m => new {
       m.DepartureTime,
       m.ArrivalTime,
       m.TravelClass
    })
    .Select(g  => g.OrderByDescending(x => x.Price).First());
