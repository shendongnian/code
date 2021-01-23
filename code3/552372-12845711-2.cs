    void GridView_RowCommand(Object sender, GridViewCommandEventArgs e)
      {
        if(e.CommandName=="Select")
        {
                var label = (Label)e.Item.FindControl("YourLabelId");
                var value = label.Text;
                Response.Redirect("CustomerUsePage.aspx?Customer_ID=" +value);
                    
        }
      }
