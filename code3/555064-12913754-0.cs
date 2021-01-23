    using (Entities context = new Entities())      
    {          
      try
      {
          try
          {
              context.Office.Add(office);
              retVal = context.SaveChanges();
          }
          catch (DbUpdateException ex)
          {
              SqlException innerException = ex.GetBaseException() as SqlException;
              if (innerException != null && innerException.Number == (int)SQLErrorCode.DUPLICATE_UNIQUE_CONSTRAINT)
              {
                  // this exception will be catched too in outer try-catch block <--------
                  throw new Exception("Error ocurred");
              }
              //This is momenty where exception is thrown.
              else
              {
                  throw ex;
              }
          }
      }
      // Catch (DbUpdateException  ex) if you plan to have the rethrown exception to be catched <------------
      catch (Exception ex)
      {
          throw new Exception("Error");
      }
  }  
