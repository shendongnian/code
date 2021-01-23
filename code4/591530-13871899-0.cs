    var query = from ticket in dataClassesDataContext.TicketsIssues
                where ticket.ClosedDate == null
                select new
                {
                    Priority = ticket.TicketPriority.TicketPriorityName,
                    Description = ticket.Description.Replace("\n", ", "),
                };
    
    if (!string.IsNullOrWhiteSpace(_filter.AssignedTo))
    {
         query = query.And(ticket => cUser.GetUserNameUsingGUID(ticket.AssignTicketToUser) == _filter.AssignedTo);
    }
