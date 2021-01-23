    public Point? GetIndex(TableLayoutPanel tlp, Point point)
    {
        // Method adapted from: stackoverflow.com/a/15449969
        if (point.X > tlp.Width || point.Y > tlp.Height)
            return null;
        int w = 0, h = 0;
        int[] widths = tlp.GetColumnWidths(), heights = tlp.GetRowHeights();
        int i;
        for (i = 0; i < widths.Length && point.X > w; i++)
        {
            w += widths[i];
        }
        int col = i - 1;
        for (i = 0; i < heights.Length && point.Y + tlp.VerticalScroll.Value > h; i++)
        {
            h += heights[i];
        }
        int row = i - 1;
        return new Point(col, row);
    }
