       class DatabaseClass
    {
        // Variables
        private string _connectionString = "";
               
        public DatabaseClass(string connectionString)
        {
            _connectionString = connectionString;  
        }
        /// Check to see if Connection can be opened
        /// 
        /// Returns True if the connection can be open else it returns False
        ///
        public bool CheckSQLConnection()
        {
            SqlConnection con = new SqlConnection(_connectionString);
            try 
	        {	        
		        con.Open();
                con.Close();
                return true;
	        }
	        catch (SqlException ex)
	        {		
		       return false;
	        }
        }
    }
