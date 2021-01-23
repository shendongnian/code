    protected void OnRowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           foreach (Control cells in e.Row.Controls)
           {
             foreach (Control link in cells.Controls)
             {
                if (link.GetType() == typeof(LinkButton))
                {
       // find your ToolkitScriptManager : here i suppose that you have a master page
                   (this.Master.FindControl("ToolkitScriptManager") as ScriptManager).RegisterAsyncPostBackControl(link);
                }
              }
           }
        }
      
    }
