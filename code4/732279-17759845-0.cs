    [Query(IsDefault = true)]
    public IQueryable<PendingLoans> GetPendingLoans()
    {
        var res = return this.context.Loads.Where(l=>!l.Releases.Any()).Select(l=> new PendingLoans { BillNo = l.BillNo }).AsQueryable()
        return res;
    }
