    using (SqlCeConnection connection = new SqlCeConnection(DBConnectionString)){
    	connection.Open();
    	
    	using (SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM Emp",connection))	
    	{
    	    
    	}
    }
