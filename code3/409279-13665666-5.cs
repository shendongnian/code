    private int _zIncrementor = 0;
    /// <summary>
    /// Hack to make two TabControls act as one.
    /// </summary>
    private void OnTabFocused(object sender, RoutedEventArgs e)
    {
        var tab = (TabControl)sender;
        var otherTab = (tab == _tabsLeft) ? _tabsRight : _tabsLeft;
        Grid.SetZIndex(tab, ++_zIncrementor);
        otherTab.SelectedItem = null;
    }
