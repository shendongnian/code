    protected void Grid_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        switch (e.Row.RowType)
        {
            case DataControlRowType.Header:
                // assuming you want to remove the underline from the second column's header
                var removeUnderlineFromColIndices = new[] { 1 };
                foreach (int cellIndex in removeUnderlineFromColIndices)
                {
                    LinkButton Link = (LinkButton)e.Row.Cells[cellIndex].Controls[0];
                    Link.Attributes.Add("style", "text-decoration:none;");
                }
                break;
        }
    }
