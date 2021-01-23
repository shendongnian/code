    protected void gridview__RowCommand(object sender, GridViewRowEventArgs e)
    {
               
          if (e.Row.RowType == DataControlRowType.DataRow)
          {
           GridViewRow gvrow = (GridViewRow(((LinkButton)e.CommandSource).NamingContainer);
    
                // To find the LinkButton
               LinkButton lnkbtn = (LinkButton)gvrow.FindControl(“lnkEdit”);
               lnkbtn .Visible = false;
          }
    
    }
