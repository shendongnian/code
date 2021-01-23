    using (EfDbContext context = CreateEfDbContext(recipient.ApplicationId.ToString()))
    {
    	var toUpdate = context.Recipients.SingleOrDefault(r => r.Id == recipient.Id);
    	if (toUpdate != null)
    	{
    		toUpdate.Field1 = recipient.Field1;
    		// Map over any other field data here.
    		
    		context.SaveChanges();
    	}
    	else
    	{
    		// Handle this case however you see fit.  Log an error, throw an error, etc...
    	}
    }
