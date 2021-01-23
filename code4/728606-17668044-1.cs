    private static void Demo1() 
       {
          SqlConnection db = new SqlConnection("connstringhere");
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
             transaction.Rollback();
          }
          db.Close();
       }
