    var projectList = dbContext.TicketUpdates.GroupBy(p => p.TicketUpdatesEmployeeId)
                        .Where( r => r.TicketUpdatesEmployeeId == Profile.EmployeeId)
                        .Select(r => r.First())
                        .OrderByDesc(q => q.TicketUpdatesEndDate)
                        .Select(n => n.First()).Ticket.Project;
