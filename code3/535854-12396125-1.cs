    protected void ddlDatabase_SelectedIndexChanged(object sender, EventArgs e)
    {
    	if (ddlDatabases.SelectedIndex != 0)
    	{
    		lbxTables.DataSource = Database.GetTables(ddlServers.Text, ddlDatabases.value);
    		lbxTables.DataBind();
    	}
    }
