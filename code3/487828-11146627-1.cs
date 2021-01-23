    protected void Grid_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        switch (e.Row.RowType)
        {
            case DataControlRowType.Header:
                int indexOfdate = ((GridView)sender).Columns
                    .Cast<DataControlField>()
                    .Select((c, index) => new {Column=c,Index=index})
                    .First(x => x.Column.HeaderText == "Date")
                    .Index;
                LinkButton Link = (LinkButton)e.Row.Cells[indexOfdate].Controls[0];
                Link.Attributes.Add("style", "text-decoration:none;");
                break;
        }
    }
