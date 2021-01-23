    public int AddedCount
    {
        get
        {
            return SpecialPriceRows.Where(r => r.Status == ChangeStatus.Added).Count();
        }
    }
