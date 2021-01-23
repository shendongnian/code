        protected void gvActivities_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           if (e.Row.RowType == DataControlRowType.DataRow)
            {
               Image img = (Image)e.Row.Cells[0].FindControl("ImageType");
               img.ImageUrl = Page.ResolveClientUrl("Image URL path);
               img.AlternateText = "Text";
               img.ToolTip = "Tooltip";
            }
        }
