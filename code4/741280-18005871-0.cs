    using (SqlConnection conn = new SqlConnection())
    {
         conn.Open();
    
         DataTable dt = new DataTable();
         using (SqlDataAdapter adapter = new SqlDataAdapter("select * from mytable", conn))
         {
              adapter.Fill(dt);
         }
    }
