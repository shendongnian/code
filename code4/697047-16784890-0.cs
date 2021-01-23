    protected void GvReportResults_RowCommand(object sender, GridViewCommandEventArgs e)
     {
        if (e.CommandName == "DeleteItem")
        {
        	int getrow = Convert.ToInt32(e.CommandArgument);
        	Label lblSourceID = (Label)GvReportResults.Rows[getrow].FindControl("lblSourceID");
        	bool flag=deleteRecord(lblSourceID.text);
        	if(flag)
        	{
        	 succes msg!
        	}
        	 else{ failed msg}
        	}
        }
        
        public bool deleteRecord(String SourceID)
        {
        try
           {
        	SqlCommand cmd = new SqlCommand("Your Delete Query where condtion  ", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }	
        catch(Exception ac)
        {
            return false;
        }
           
     }
