    public static void SetScrollPosition(this DataGrid grid, ScrollInfo info)
    {
        if (info.HorizontalPosition > 0)
        {
            ScrollBar sbHorizontal = grid.GetScrollbar(ScrollMode.Horizontal);
            sbHorizontal.Maximum = info.HorizontalMaximum;
            grid.Scroll(ScrollMode.Horizontal, info.HorizontalPosition);
        }
        if (info.VerticalPosition > 0)
        {
            ScrollBar sbVertical = grid.GetScrollbar(ScrollMode.Vertical);
            sbVertical.Maximum = info.VerticalMaximum;            
            grid.Scroll(ScrollMode.Vertical, info.VerticalPosition);
        }
    }
