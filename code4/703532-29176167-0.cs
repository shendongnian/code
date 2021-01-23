    var tickets =
         context.TicketDetails
        .Where(t => t.DateScheduled >= DateTime.Now)
        .OrderBy(t => t.DateScheduled)
        .Take(3)
        .Include(t => t.Ticket)
        .Include(t => t.Ticket.Feature)
        .Include(t => t.Ticket.Feature.Property)
        .AsEnumerable()
        .Select(
            t =>
            new {
                ID = t.Ticket.ID,
                Address = t.Ticket.Feature.Property.Address,
                Subject = t.Ticket.Subject,
                DateScheduled = String.Format("{0:MMMM dd, yyyy}", t.DateScheduled)
        }
    );
