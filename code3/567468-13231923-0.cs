        objConnection = new OleDbConnection(strConnection);
        objConnection.ConnectionString = strConnection;
    
        objConnection.Open();
    
    
    
        // set the SQL string
        strSQL = "INSERT INTO test_table (username,password) " +
        "VALUES (@user,@pass)";
        // Create the Command and set its properties
        objCmd = new OleDbCommand(strSQL, objConnection);
    
        objCmd.Parameters.AddWithValue("@user", TextBox1.Text);
    
        objCmd.Parameters.AddWithValue("@pass", TextBox2.Text);
    
        // execute the command
        objCmd.ExecuteNonQuery();
    
        objConnection.Close();
