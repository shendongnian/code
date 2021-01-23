    protected void uxCustomGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {                           
                  
               LinkButton uxEditLinkButton = (LinkButton)e.Row.FindControl("uxEditLinkButton");
               uxEditLinkButton.Attributes["onclick"] = string.Format("return doEdit({0})", item.ID);      
            }
        }
