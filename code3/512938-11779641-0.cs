    using (var ctx = new DatabaseEntities())
    {
    	ctx.Contacts.Attach(cont);
    	// Marks all properties as modified, so new values will be pushed to DB on SaveChanges
    	ctx.ObjectStateManager.ChangeObjectState(cont, System.Data.EntityState.Modified);
    	ctx.SaveChanges();
    }
