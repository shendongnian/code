    using(var ctx = new MyContext())
    {
        var query = ctx.Order;
        
        if(setFromDate)
            query = query.Where(ent=> ent.TradeDate >= fromDate);
        if(setToDate)
            query = query.Where(ent => ent.TradeDate <= toDate);
        if(String.IsNullOrWhitespace(buyCompany) == false)
            query = query.Where(ent => ent.BuyCompany.CompanyName = buyCompany);
        //(snip)
        return query.ToList();
    }
