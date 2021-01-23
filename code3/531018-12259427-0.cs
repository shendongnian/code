    var result = tickets.GroupBy(t => t.EventName)
                        .Select(g  => new { 
                                 EventName = g.Key, 
                                 TicketCount = g.Sum(t => t.TicketCount), 
                                 Price = g.Sum(t => t.Price)
                        });
    foreach(var x in result)
         Console.WriteLine("EventName = {0}, TicketCount = {1}, Price = {2}"
                           , x.EventName , x.TicketCount , x.Price);
