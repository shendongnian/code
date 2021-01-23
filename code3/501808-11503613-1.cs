            using (var conn = new SqlConnection(_thisConnectionString))
            {
               SqlCommand cmd = conn.CreateCommand();
               cmd.CommandText = "Your SQL Query STuff";
  
                conn.Open();
             }        
      
 
