    void test() {
        using (var t = new TransactionScope())
        using (var c = new SqlConnection(constring))
        {
            c.Open();
            try 
            {
                 using (var s = new SqlCommand("Update table SET column1 = 1");
                 {
                       s.ExecuteScalar();  // If this fails
                 }
                 t.Complete();
            }
            catch (Exception ex)
            {
                 SaveErrorToDB(ex, c);  // I don't want to run this in the same transaction
            }
        }
    }
    
    void SaveErrorToDB(Exception ex, SqlConnection c) {
          using (var cmd = new SqlCommand("INSERT INTO ErrorLog (msg) VALUES (" + ex.Message + ", c))
          {
                cmd.ExecuteNonQuery();
          }
    }
