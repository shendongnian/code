    private void ScaleListViewColumns(ListView listview, SizeF factor)
    {
        foreach (ColumnHeader column in listview.Columns)
        {
            column.Width = (int)Math.Round(column.Width * factor.Width);
        }
    }
    protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
    {
        base.ScaleControl(factor, specified);
        ScaleListViewColumns(listView1, factor);
    }
