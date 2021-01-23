    public static void UpdateItemSource(this DataGrid grid, IEnumerable itemSource)
    {
        ScrollInfo oInfo = grid.GetScrollInfo();
        grid.ItemsSource = itemSource;
        grid.SetScrollPosition(oInfo);
    }
