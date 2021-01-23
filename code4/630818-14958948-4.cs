    protected void grid_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
       if(e.CommandName == "DeleteRow")
       {
          foreach(DataRow row in dt.Rows)
          {
             if(Convert.ToInt32(row["YourColumnID"]) == Convert.ToInt32(e.CommandArgument))
                row.Delete();
          }
          dt.AcceptChanges();
          gvDisplay.DataSource = dt;
          gvDisplay.DataBind();
       }
    }
