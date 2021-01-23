    protected void rblShowRecords_SelectedIndexChanged(object sender, EventArgs e)
    {
    	CEDatabaseSource.SelectCommand = GetCommand();
    	CEDatabaseSource.DataBind(); //Commit the changes to the data source.
    	gvRecordList.DataBind(); //Update the GridView
    }
