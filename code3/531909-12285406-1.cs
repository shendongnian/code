    protected void GridView_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        string m_id = e.CommandArgument.ToString();
        if (e.CommandName == "Something")
        {
           //do something with m_id
        }
    }    
