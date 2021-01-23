    con.Open(); 
    
    using (SqlCommand cmd = new SqlCommand("submitdata", con))
    {
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter param1 = new SqlParameter("@Firstname", SqlDbType.VarChar);
        param1.Value = "my first name";
       
         // ... the rest params
        cmd.Parameters.Add(param1);
        
        // cmd.Parameters.Add(param2);....
        cmd.ExecuteNonQuery(); 
    }
    
    con.Close();
