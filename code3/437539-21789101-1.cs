    if ((sender as ListView)?.View is GridView gridview)
    {
        foreach (var column in gridview.Columns)
        {
            // Set the Width. Then clear it to cause the autosize.
            column.Width = 1;
            column.ClearValue(GridViewColumn.WidthProperty);
        }
    }
