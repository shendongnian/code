    // This is the template method which takes care of all the duplicated steps. This method only needs to be written once...
    public IDatabaseError GetUserByName(string Name)
    {
       try
      {
          //Initialize session to database
      }
      catch (Exception)
      {
         // return error with description for this step
      }
      try
      {
           // Try to create 'transaction' object
      }
      catch(Exception)
      {
         // return error with description about this step
      }
      try
      {  
          // Execute the unique part of the method...
          GetUserByNameImpl(name);
      }
      catch(Exception)
      {
          // Transaction object rollback
          // Return error with description for this step
      }
      finally
      {
          // Close session to database
      }
      return everything-is-ok  
    }
    void GetUserByNameImpl(string name)
    {
        // Execute call to database with session and transaction object
        //
        // Actually in all function only this section of the code is different
        //
    }
