    Call call = new Call()
    {
    
        ....
    
        StoreID = storeID,    //foreign key of store
    
        ....
    
    }
    
    db.Calls.Add(call);
    
    db.SaveChanges();
    call = db.Calls.Single(c => c.CallId = call.CallId).Include(c => c.Store);
    
    ....
    
    // do something with store
    
    call.Store.Anything();
