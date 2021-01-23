    DbContext.Configuration.AutoDetectChangesEnabled = false;
    DbContext.Entry(myobj).State = EntityState.Unchanged;
    foreach (OtherObj otherObj in otherObjList)
        DbContext.Entry(otherObj).State = EntityState.Unchanged;
    // entering MyObj_Save method here
    foreach (OtherObj otherObj in otherObjList)
    {
        //DbContext.OtherObj.Attach(otherObj); // does not have an effect
        myobj.OtherObj.Add(otherObj);
    }
    DbContext.Entry(myobj).State = EntityState.Added;
    DbContext.SaveChanges();
