    public IQueryable<Ticket> getTicketbyArea(int dllAreaNum)
    {
         var _db = new TicketContext();
    
         var query = _db.Tickets
                        .Where(x => x.AreaID== dllAreaNum).Select(x =>x)
                      return query;
    
    }
