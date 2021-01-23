    var query = from ticket in dataClassesDataContext.TicketsIssues
                where ticket.ClosedDate == null 
                && (string.IsNullOrWhiteSpace(_filter.AssignedTo) ? true : cUser.GetUserNameUsingGUID(ticket.AssignTicketToUser) == _filter.AssignedTo)                                                   
                select new
                {
                    Priority = ticket.TicketPriority.TicketPriorityName,
                    Description = ticket.Description.Replace("\n", ", "),
                };
