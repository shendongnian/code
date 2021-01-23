    var projects = (from update in dbContext.TicketUpdates
               where update.TicketUpdatesEmployeeID == Profile.EmployeeID
               orderby update.TicketUpdatesEndDate descending
               select update.Ticket.Project);
    var seen = new HashSet<Project>();
    foreach (var project in projects)
    {
        if (seen.Add(project))
        {
            // A distinct project
        }
    }
