    private bool checkConnectionSuccess(string host, string user, string pass, string dbname)
    {
       string connectionString = "Data Source=" + host + ";Database=" + dbname + ";User ID=" + user + ";Password=" + pass;
    
       bool sucessful = true;
       
       using (MySqlConnection conn = new MySqlConnection (connectionString))
       {
    	 try
    	 {
    	   conn.Open();
    	 }
    	 catch (MySqlException ex)
    	 {
    	   sucessful = false;
    	 }
       }
    	return sucessful;
    }
