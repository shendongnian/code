     private void BuildPageAppBarDictionary()
     {
        _appbarDictionary.Clear();
    
        foreach (var item in MyFlipView.Items)
        {
            var page = item as Page;
            Tuple<AppBar, AppBar> appbars = new Tuple<AppBar, AppBar>(page.TopAppBar, page.BottomAppBar);
            _appbarDictionary.Add(page, appbars);
        }
    }
    private void InitializeAppBar(FlipView flipView)
    {
        if (_appbarDictionary.Count > 0)
        {
            var currentPage = flipView.SelectedItem as Page;
            currentPage.TopAppBar = _appbarDictionary[currentPage].Item1;
            currentPage.BottomAppBar = _appbarDictionary[currentPage].Item2;
    
            if (currentPage.TopAppBar != null)
            {
                currentPage.TopAppBar.IsEnabled = true;
            }
    
            if (currentPage.BottomAppBar != null)
            {
                currentPage.BottomAppBar.IsEnabled = true;
            }
        }
    }
    
    private void NullOtherAppBars(FlipView flipView)
        {
            foreach (var item in MyFlipView.Items)
            {
                if (item != flipView.SelectedItem)
                {
                    var page = item as Page;
    
                    page.TopAppBar = null;
                    page.BottomAppBar = null;
                }
            }
        }
