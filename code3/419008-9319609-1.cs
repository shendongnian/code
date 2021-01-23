    using (var con = new SqlConnection(ConnectionString)) {
    	int newID;
    	using (var insertCommand = new SqlCommand("INSERT INTO foo (column_name)VALUES (@Value) ;SELECT CAST(scope_identity() AS int)", con)) {
    		insertCommand.Parameters.AddWithValue("@Value", "bar");
    		con.Open();
    		newID = (int)insertCommand.ExecuteScalar();
        }
    }
    
