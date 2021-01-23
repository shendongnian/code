    string connStr = @"provider= microsoft.jet.oledb.4.0;data source=sample.mdb";
    string test = "insert into inlog ([PASSWORD], Username, leeftijd, gewicht) VALUES (?, ?, ?, ?)";
    
    using(OleDbConnection vcon = new OleDbConnection(connStr))
    {
    	using(OleDbCommand vcom = new OleDbCommand(test, vcon))
    	{
    		vcom.Parameters.AddWithValue("PASSWORD", textBox2.Text);
    		vcom.Parameters.AddWithValue("Username", textBox1.Text);
    		vcom.Parameters.AddWithValue("leeftijd", textBox3.Text);
    		vcom.Parameters.AddWithValue("gewicht", textBox4.Text);
    		try
    		{
    			vcon.Open();
    			com.ExecuteNonQuery();
    		}
    		catch(OleDbException ex)
    		{
    			// do something with the exception
    		}
    	}
    }
