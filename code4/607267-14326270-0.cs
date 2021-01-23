    SqlDataAdapter da = new SqlDataAdapter();
    	DataTable dt = new DataTable();
    
    	// Create the SelectCommand using paramaterized queries
        	SqlCommand command = new SqlCommand("SELECT * FROM ListaAdresow WHERE Email = @Email", connection);
    	command.Parameters.Add("@Email", SqlDbType.VarChar, 40, TextBox1.Text);
    
    	da.SelectCommand = command;
    	da.Fill(dt);
    
    	if (dt.Rows.Count > 0)
    	{
    		//Row Exists
    	}
    	else
    	{
    		//Row Does Not Exist
    	}
