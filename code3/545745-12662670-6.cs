    string updateCommand = "UPDATE RoomsTable SET [Date Checked]=@checkedDate WHERE ID = @id"; // '9/27/2012'
    using (OleDbConnection conn = new OleDbConnection("connectionStringHERE"))
    {
    	using (OleDbCommand comm = new OleDbCommand())
    	{
    		comm.Connection = conn;
    		comm.CommandText = updateCommand;
    		comm.CommandType = CommandType.Text
    		comm.Parameters.AddWithValue("@checkedDate", this.dateTimePicker1.Value)
            comm.Parameters.AddWithValue("@id", row.roomID);
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
