    private Lazy<Ticket> ticket = new Lazy<Ticket>(() => new Ticket(TicketID, ClientID, ConnectionString, Person.PersonID));
    
    public Ticket Ticket
    {
        get { return ticket.Value; }
    }
