    using (SqlConnection con = new SqlConnection())
    {
         bool sqlErrorOccurred;
         try
         {
             con.Open();
             sqlErrorOccurred = false;
         }
         catch (SqlException ex)
         {
              sqlErrorOccurred = true;
         }
         if(sqlErrorOccurred)
         {
             MessageBox.Show("A Sql Exception Occurred");
         }
    }
