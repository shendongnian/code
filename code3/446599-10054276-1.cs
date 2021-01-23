    protected void YourGrid_RowCommand(Object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName=="View")
        {
          int index = Convert.ToInt32(e.CommandArgument);
        }
    }
    protected void YourGrid_RowCreated(Object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
          var LinkButton2 = (LinkButton)e.Row.FindControl("LinkButton2");
          LinkButton2.CommandArgument = e.Row.RowIndex.ToString();
        }
    
    }
