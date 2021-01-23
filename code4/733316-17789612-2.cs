    IQueryable<CustCommPreference> query = _marketoEntities.CustCommPreferences.AsQueryable();
    if (!string.IsNullOrEmpty(cusid)) 
        query = query.Where(x => x.MasterCustomerID == cusid);
    if (!string.IsNullOrEmpty(mktid)) 
        query = query.Where(x => x.MarketID == mktid);
