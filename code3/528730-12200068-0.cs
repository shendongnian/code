    Database_Name database_name = db.Database_Name.Find(id);
    database_name.Deleted="Y";
    db.Database_Name.Attach(database_name);
    db.Entry(database_name).State = EntityState.Modified;
    try
    {        
       db.SaveChanges();
    }
    catch (DbUpdateConcurrencyException ex)
    {
        ex.Entries.Single().Reload();
        context.SaveChanges();        
    }
    catch (Exception ex2)
    {
        //some error. Log it 
    }
 
