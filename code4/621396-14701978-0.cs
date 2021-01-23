    var query = /*Your query*/;
    foreach (var t in query)
    {
        t.STATUS ="1";
        db.Entry(t).State = System.Data.EntityState.Modified;
    }
    
    db.SaveChanges();
