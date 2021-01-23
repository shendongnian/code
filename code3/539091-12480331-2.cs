    IList<Project> projects = (from update in dbContext.TicketUpdates where update.TicketUpdatesEmployeeID == Profile.EmployeeID)
        .GroupBy(tu=>tu.Ticket.Project)
        .Select(group=>group.First())
        .OrderByDescending(tu=>tu.TicketUpdatesEndDate)
        .Select(tu=>tu.Ticket.Project)
        .ToList();
