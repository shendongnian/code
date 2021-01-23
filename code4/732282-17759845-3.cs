    [Query(IsDefault = true)]
    public IQueryable<PendingLoans> GetPendingLoans()
    {
        var res = from l in this.context.Loans
                  where l.Releases.Count() == 0
                  select new PendingLoans { BillNo = l.BillNo };
        return res.AsQueryable();
    
    }
