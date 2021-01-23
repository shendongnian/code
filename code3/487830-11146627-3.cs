    protected void Grid_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        switch (e.Row.RowType)
        {
            case DataControlRowType.Header:
                var notDateFields = ((GridView)sender).Columns
                     .Cast<DataControlField>()
                     .Select((c, index) => new { Column = c, Index = index })
                     .Where(x => x.Column.HeaderText != "Date");
                foreach (var field in notDateFields)
                {
                    LinkButton Link = (LinkButton)e.Row.Cells[field.Index].Controls[0];
                    Link.Attributes.Add("style", "text-decoration:none;");
                }
                break;
        }
    }
