    protected void gridReport_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ProdCode")
        {   
            System.Diagnostics.Debug.WriteLine("This is the value " + e.CommandArgument);
        }
    }
