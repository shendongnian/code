    public static SupportTicket Find(int id)
    {
        using (DatabaseContext db = new DatabaseContext())
        {
            SupportTicket ticket = db.SupportTickets.Include("Owner").SingleOrDefault(x => x.Id == id);
            // or SupportTicket ticket = db.SupportTickets.Include(st => st.Owner).SingleOrDefault(x => x.Id == id);
            return ticket;
        }
    }
