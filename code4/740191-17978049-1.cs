    Nullable<DateTime> fromDate = //...
    Nullable<DateTime> toDate = //...
    string buyCompany = //...
    //(Snip)
    using(var ctx = new MyContext())
    {
        var query = ctx.Order;
        
        if(fromDate.HasValue)
            query = query.Where(ent=> ent.TradeDate >= fromDate.Value);
        if(toDate.HasValue)
            query = query.Where(ent => ent.TradeDate <= toDate.Value);
        if(String.IsNullOrWhitespace(buyCompany) == false)
            query = query.Where(ent => ent.BuyCompany.CompanyName = buyCompany);
        //(Snip)
        return query.ToList();
    }
