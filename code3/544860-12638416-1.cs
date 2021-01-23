     if (e.Row.RowType == DataControlRowType.DataRow)
        {
             Image img = (Image)e.Row.Cells[0].FindControl("ImageType");
             img.ImageUrl = Page.ResolveClientUrl("Image URL path);
             img.AlternateText = "פעילות מסוג רב ברירה";
             img.ToolTip = "פעילות מסוג רב ברירה";
        }
