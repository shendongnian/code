    string updateCommand = "UPDATE RoomsTable SET Date Checked=@checkedDate"; // '9/27/2012'
    using (OleDbConnection conn = new OleDbConnection("connectionStringHERE"))
    {
    	using (OleDbCommand comm = new OleDbCommand())
    	{
    		comm.Connection = conn;
    		comm.CommandText = updateCommand;
    		comm.CommandType = CommandType.Text
    		comm.Parameters.AddWithValue("@checkedDate", '9/27/2012')
    		try
    		{
    			comm.Open();
    			conn.ExecuteNonQuery();
    		}
    		catch(OleDbException ex)
    		{
    			MessageBox.Show(ex.Message.ToString());
    		}
    	}
    }
