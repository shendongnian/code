    [Query(IsDefault = true)]
    public IQueryable<PendingLoans> GetPendingLoans()
    {
        var res = this.context.Loans.Where(l=>l.Releases.Count() == 0).Select(l=> new PendingLoans { BillNo = l.BillNo }).AsQueryable();
        return res;
    }
