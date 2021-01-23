    public IQueryable<qry_ClientList> GetQry_ClientList(Guid Key)
    {
        List<qry_ClientList> clients = 
            this.ObjectContext.qry_ClientList.OrderBy(p => p.ClientCode).ToList();
        foreach (qry_ClientList c in clients) {
            Decrypt(c);
        }
        return clients.AsQueryable;
    }
