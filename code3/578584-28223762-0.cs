    SqlDataAdapter viewAdapter = new SqlDataAdapter("Select * From Users", DBConn);
    SqlCommandBuilder builder = new SqlCommandBuilder(viewAdapter);
    viewAdapter.UpdateCommand = builder.GetUpdateCommand();
    
    
    DataTable Users = new DataTable();
    viewAdapter.Fill(Users);
    foreach (DataRow user in Users.Rows)
    {
    	foreach (DataColumn c in Users.Columns)
    	{
    		Console.WriteLine(c.ColumnName);
    		if (c.DataType != typeof(DateTime))
    		{
    			// Clean up empty space around field entries
    			user[c.ColumnName] = user[c.ColumnName].ToString().Trim();
    		}
    
    	}
       // user.AcceptChanges(); 
       // Do not do an accept changes for either the table or the row before your ViewAdapter Update. 
       // It will appear as though you do not have changes to push.
    }
    
    // Users.AcceptChanges();
    viewAdapter.Update(Users);
    
