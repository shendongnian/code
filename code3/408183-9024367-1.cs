    private void AddCustomer(string customerName, string customerPhone)
    {
    	string name = customerName;
    	string phone = customerPhone;
    
    	// An easy way to determine the connection string to your database is to open the database from Visual Studio's 'Server Explorer'.
    	// Then, from Server Explorer, view the Properties of the database - in the Properties you will see the "Connection String". 
    	// You can/should replace the arbitrary part of the path with "|DataDirectory|".
    	string connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|MyDb.accdb;Persist Security Info=True";
    
    	// Create your sql query in a string variable
    	string cmdText = string.Format("INSERT INTO Customer(Name, Phone) VALUES('{0}','{1}');", name, phone);
    
    	// Use the 'using' statement on your connection so that the resource is managed properly
    	using (System.Data.OleDb.OleDbConnection connection = new System.Data.OleDb.OleDbConnection(connString))
    	{                
    		// Here's where/how we fire off the INSERT statement
    		OleDbCommand cmd = new OleDbCommand(cmdText, connection);
    		connection.Open();
    		cmd.ExecuteNonQuery();
    	}
    }
