    TicketStatus completeStatus = _db.TicketStatuses.Single(s => s.Status == "Complete");
    Client entityClient = _db.Clients.Single(c => c.ClientID == client.ClientID);
    DashboardSupportView supportView = new DashboardSupportView();
    supportView.OpenTickets = entityClient.Tickets.Count(t.TicketStatus.TicketStatusID != completeStatus.TicketStatusID);
    supportView.ClosedTickets = entityClient.Tickets.Count(t.TicketStatus.TicketStatusID == completeStatus.TicketStatusID);
    return PartialView(supportView)
