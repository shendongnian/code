    var events = tickets.GroupBy(t => t.EventName).Select(g => new 
    {
      EventName = g.Key,
      TicketCount = g.Sum(t => t.TicketCount),
      Price = g.Sum(t => t.Price)
    });
