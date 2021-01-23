    public IEnumerable<Message> GetMessagesFromApi(DateTime? dateFrom = null, DateTime? dateTo = null, int flag = -1, int messageType = 1, bool media =false)
    {
        IQueryable<Message> query = db.Messages;
        if(dateFrom.HasValue)
            query = query.Where(x => x.Created >= dateFrom);
        if(dateTo.HasValue)
            query = query.Where(x => x.Created <= dateTo);
        if(flag >= 0)
            query = query.Where(x => x.Flag == flag);
        // others as needed, such as media...
        return query.ToList();
    }
