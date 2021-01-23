    TicketStatus completeStatus = _db.TicketStatuses.Single(s => s.Status == "Complete");
    DashboardSupportView supportView = new DashboardSupportView();
    supportView.OpenTickets = _db.Tickets.Count(t => t.ClientID == client.ClientID && t.TicketStatus.TicketStatusID != completeStatus.TicketStatusID);
    supportView.ClosedTickets = _db.Tickets.Count(t => t.ClientID == client.ClientID &&  t.TicketStatus.TicketStatusID == completeStatus.TicketStatusID);
    return PartialView(supportView)
