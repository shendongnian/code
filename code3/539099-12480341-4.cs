    var projects = dbContext.TicketUpdates
        .Where(uu => uu.TicketUpdatesEmployeeID == Profile.EmployeeID)
        .GroupBy(uu => uu.Ticket.Project)
        .OrderByDescending(gg => gg.Max(uu => uu.TicketUpdatesEndDate))
        .Select(gg => gg.Key);
