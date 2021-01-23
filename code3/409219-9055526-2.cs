    public static void execute(String query) {
        SqlConnection c = null;
        try { 
          c = connection;
          using ( SqlCommand com = new SqlCommand(query, c);                 
             com.ExecuteNonQuery();
        }
        finally {
           if ( c!=null)
             c.Close();
        }
    } 
