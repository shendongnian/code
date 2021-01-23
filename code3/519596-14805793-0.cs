    private void MyFlipView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var flipView = sender as FlipView;
        BuildPageAppBarDictionary();
        InitializeAppBar(flipView);
        NullOtherAppBars(flipView);
    }
