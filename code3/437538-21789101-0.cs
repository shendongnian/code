    var theListView = sender as ListView;
    var theGridView = theListView.View as GridView;
    foreach (var column in theGridView.Columns)
    {
        // Set the Width. Then clear it to cause the autosize.
        column.Width = 1;
        column.ClearValue(GridViewColumn.WidthProperty);
    }
