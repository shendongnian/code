    string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\SB18\Documents\Visual Studio 2010\Projects\AzureSecureStore\AzureSecureStore\AzcureSecureStore Database.accdb; Persist Security Info=False;";
    string query = "INSERT INTO Client VALUES(@col1,@col2,@col3,@col4,@col5,@col6)";
    using (OleDbConnection conn = new OleDbConnection(connStr))
    {
    	using (OleDbCommand comm = new OleDbCommand())
    	{
    		comm.Connection = conn;
    		comm.CommandText = query;
    		comm.CommandType = CommandType.Text;
    		comm.Parameters.AddWithValue("@col1", textBox1.Text);
    		comm.Parameters.AddWithValue("@col2", textBox2.Text);
    		comm.Parameters.AddWithValue("@col3", int.Parse(textBox3.Text));
    		comm.Parameters.AddWithValue("@col4", int.Parse(textBox4.Text));
    		comm.Parameters.AddWithValue("@col5", textBox9.Text);
    		comm.Parameters.AddWithValue("@col6", int.Parse(textBox10.Text));
    		try
    		{
    			conn.Open();
    			comm.ExecuteNonQuery();
    			MessageBox.Show("Data stored successfully");
    		}
    		catch(OleDbException e)
    		{
    			MessageBox.Show(e.ToString());
    		}
    	}
    }
