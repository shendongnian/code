    var groupedByEvent = tickets.GroupBy(t => t.EventName);
    
    var obj = groupByEvent.Select(group => new {
       EventName = group._Key,
       TicketCount = group.Sum(x => x.TicketCount),
       Price = group.Sum(x => x.Price)
    });
