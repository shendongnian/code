    var query = _marketoEntities.CustCommPreferences;
    if (!string.IsNullOrEmpty(cusid)) 
        query = query.Where(x => x.MasterCustomerID == cusid);
    if (!string.IsNullOrEmpty(mktid)) 
        query = query.Where(x => x.MarketID == mktid);
