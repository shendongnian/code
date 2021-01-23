    private Ticket _ticket;
    ...
    public Ticket Ticket
    {
        get
        {
            if (this._ticket == null)
            {
                this._ticket = new Ticket(TicketID, ClientID, ConnectionString, Person.PersonID);
            }
            return this._ticket;
        }
    }
