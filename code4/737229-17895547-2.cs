    using (SqlConnection con = new SqlConnection(myConnection.GetConnectionString()))
    using (SqlCommand commad = new SqlCommand("sql statements", con))
    {
        con.Open();
        commad.ExecuteNonQuery(); 
        //var result = commad.ExecuteScalar();
        
    }
