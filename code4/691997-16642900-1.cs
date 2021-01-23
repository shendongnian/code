     private int getEmail(string email, string password) 
     { 
       string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString; 
       using (SqlConnection conn = new SqlConnection(cs)) 
       {  
         conn.Open(); 
         SqlCommand cmd = new SqlCommand("sp_addEmailReturnid", conn); 
         cmd.CommandType = CommandType.StoredProcedure; 
         cmd.Parameters.AddWithValue("@email", email); 
         cmd.Parameters.AddWithValue("@password",password); 
         int nUploadId = Convert.ToInt32(cmd1.ExecuteScalar()); } // Updated Part
