    string connStr = "Server=***;Port=***;Database=***;Uid=***;Pwd=***;";
    string query = "SELECT count(Dues) From Students";
    using(MySqlConnection sqlCon = new MySqlConnection(connStr))
    {
    	using(MySqlCommand sqlComm = new MySqlCommand())
    	{
    		sqlComm.Connection = sqlCon;
    		sqlComm.CommandText = query;
    		
    		try
    		{
    			sqlCon.Open();
    			TextBox1.Text = sqlComm.ExecuteScalar().ToString();
    		}
    		catch(MySqlException ex)
    		{
    			MessageBox.Show(ex.ToString());
    		}
    	}
    }
