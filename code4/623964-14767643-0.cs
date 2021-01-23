    private IEnumerable<Ticket> GetTickets()
    {
        // Try to get the tickets from the cache first:
        var tickets = MemoryCache.Default["tickets"] as IEnumerable<Ticket>;
        if (tickets == null)
        {
            // not found in cache, let's fetch them from the database:
            tickets = db.Tickets.ToList();
            // and now store them into the cache so that next time they will be available
            MemoryCache.Default.Add("tickets", tickets, new CacheItemPolicy { Priority = CacheItemPriority.NotRemovable });
        }
    
        return tickets;
    }
