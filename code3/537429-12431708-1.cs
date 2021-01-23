    public static void CreatePublication(string server, List<string> queries)    
    {    
        string finalConnString = Properties.Settings.Default.rawConnectionString.Replace("<<DATA_SOURCE>>", server).Replace("<<INITIAL_CATALOG>>", "tempdb");    
        
         using (SqlConnection conn = new SqlConnection(finalConnString))    
         {    
             conn.Open();    
             foreach(string query in queries)
             {
                 using (SqlCommand cmd = new SqlCommand(query, conn))    
                 {    
                     cmd.ExecuteNonQuery();    
                 }
             }    
          }    
    }
   
