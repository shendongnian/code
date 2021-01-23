    private string MemID{
        get { return (String)ViewState["MemID"]; }
        set { ViewState["MemID"] = value; }
    }
    
    private void BindGrid()
    {
        // copy your sql,datasource and databind stuff here, use the MemID property for the parameter
    }
    
    protected void gvTemp_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Start")
        {
            MemID = e.CommandArgument.ToString());
            BindGrid();
        }
    }
