    public static void Scroll(this DataGrid grid, ScrollMode mode, double position)
    {
        // Get the scrollbar and convert the position to percent.
        var scrollBar = grid.GetScrollbar(mode);
        double positionPct = ((position / scrollBar.Maximum) * 100);
        // Scroll to a specfic percentage of the scrollbar.
        grid.ScrollToPercent(mode, positionPct);
    }
    public static void ScrollToPercent(this DataGrid grid, ScrollMode mode, double percent)
    {
        // Fix the percentage.
        if (percent < 0)
            percent = 0;
        else if (percent > 100)
            percent = 100;
        // Get the scroll provider.
        var scrollProvider = GetScrollProvider(grid);
 
        // Scroll.
        switch (mode)
        {
            case ScrollMode.Vertical:                        
                scrollProvider.SetScrollPercent( System.Windows.Automation.ScrollPatternIdentifiers.NoScroll, percent);
                break;
            case ScrollMode.Horizontal:
                scrollProvider.SetScrollPercent(percent, System.Windows.Automation.ScrollPatternIdentifiers.NoScroll);
                break;
        }
    }
