    using(SqlConnection spojeni = new SqlConnection(conString))
    using(SqlCommand novyprikaz2 = new SqlCommand("SELECT pocet FROM klisluz " + 
                                                  "WHERE id = @id",spojeni); 
    {
         novyprikaz2.Parameters.AddWithValue("@id", vyberradek);
         spojeni.Open();
         using(SqlDataAdapter da = new SqlDataAdapter(novyprikaz2))
         {
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtg_ksluzby.DataSource = dt;
            
         }
     }
