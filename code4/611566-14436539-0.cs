    private Ticket _Ticket = null;
    
    public Ticket Ticket
    {
        get
        {
            return this._Ticket != null ? this._Ticket : (this._Ticket = new Ticket(TicketID, ClientID, ConnectionString, Person.PersonID));
        }
    }
