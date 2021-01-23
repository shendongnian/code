    var query = db.Vouchers;
    if (...)
    {       
       query = query.Where(v => v.Title.Contains(Search.SearchText);
    }
    if (...)
    {       
       query = query.Where(v => v.Status == Search.Status);
    }
    // etc
    List<Voucher> list = query.Take(100).ToList();    
    
