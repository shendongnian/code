          SqlConnection conn = new SqlConnection("Your Connection string");
          conn.Open()
          using (SqlTransaction tran = conn.BeginTransaction()) {
          try {
          // your code
          tran.Commit();
          }  catch {
           tran.Rollback();
           throw;
          }
          }
