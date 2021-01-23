    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            foreach (TableCell tc in e.Row.Cells)
            {
                if (tc.HasControls())
                {
                    // search for the header link
                    LinkButton lnk = (LinkButton)tc.Controls[0];
                    if (lnk != null && GridView1.SortExpression == lnk.CommandArgument)
                    {
                        // inizialize a new image
                        System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
                        // setting the dynamically URL of the image
                        img.ImageUrl = "~/img/ico_" + (GridView1.SortDirection == SortDirection.Ascending ? "asc" : "desc") + ".gif";
                        // adding a space and the image to the header link
                        tc.Controls.Add(new LiteralControl(" "));
                        tc.Controls.Add(img);
    
                    }
                }
            }
        }
    }
