    protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      if (e.CommandName == "editForm")
        {
          GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
          string value=grdView.DataKeys[row.RowIndex].Values["myDataKey"].ToString();
        }
    }
