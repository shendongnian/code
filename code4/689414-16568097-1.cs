    .GroupBy(m => new {
       m.DepartureTime,
       m.ArrivalTime,
       m.TravelClass
    })
    .Select(g  => g.OrderBy(x => x.Price).First());
