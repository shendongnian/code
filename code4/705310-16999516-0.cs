    using (SqlConnection conn = new SqlConnection(Connection.getConnection()))
    using (SqlCommand sp = new SqlCommand(name-of-sp, conn))
    {
           sp.CommandType = CommandType.StoredProcedure;
 
           conn.Open();
           
           using (SqlDataReader rdr = sp.ExecuteReader())
           {
              while (rdr.Read())
              {
                 // read the values from the data reader, e.g.
                 // adapt to match your actual query! You didn't mentioned *what columns*
                 // are being returned, and what data type they are
                 string colValue1 = rdr.GetString(0);
                 int colValue2 = rdr.GetInt(1);
              }
           }
           conn.Close();
    }
    
