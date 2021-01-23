    bool oldValidateOnSaveEnabled = localDb.Configuration.ValidateOnSaveEnabled;
    try
    {
      localDb.Configuration.ValidateOnSaveEnabled = false;
      var customer = new Customer { CustomerId = id };
      
      localDb.Customers.Attach(customer);
      localDb.Entry(customer).State = EntityState.Deleted;
      localDb.SaveChanges();
    }
    finally
    {
      localDb.Configuration.ValidateOnSaveEnabled = oldValidateOnSaveEnabled;
    }
