    private void RenderGridViewRowWithHeader(HtmlTextWriter output, Control container)
    {
        // Render group header
        var row = new TableRow { CssClass = "groupingCssClass" };
        row.Cells.Add(new TableCell());
        row.Cells.Add(new TableCell
        {
            ColumnSpan = ((GridViewRow)container).Cells.Count - 1,
            Text = _groupNames[container]
        });
        row.RenderControl(output);
        // Render row
        container.SetRenderMethodDelegate(null); // avoid recursive call
        container.RenderControl(output);
    }
