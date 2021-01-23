    private static void Update() 
       {
          SqlConnection db = new SqlConnection("strConectionString");
          SqlTransaction transaction;
    
          db.Open();
          transaction = db.BeginTransaction();
          try 
          {
             new SqlCommand("update quey1", db, transaction)
                .ExecuteNonQuery();
             new SqlCommand("update quey2", db, transaction)
                .ExecuteNonQuery();
             new SqlCommand("update quey3", db, transaction)
                .ExecuteNonQuery();
             transaction.Commit();
          } 
          catch (SqlException sqlError) 
          {
             // always log or rethrow exceptions!
             transaction.Rollback();
             db.Close();
             //
             throw;
          }
          db.Close();
       }
