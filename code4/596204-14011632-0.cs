    public static class TicketExtensions {
      public static Dictionary<string, List<Ticket>> groupByName(this List<Ticket> tickets) {
        // returns the map of name/tickets
      }
    }
    ...
    var ticket = new Ticket();
    var tickets = new List<Tickets>();
    var service = new TicketService();
    service.acceptTicket(ticket);
    // leaving out the creation of a list of tickets...
    var groups = tickets.groupByName();
