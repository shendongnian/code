    bool _navigationServiceAssigned = false;
    private void page_Loaded(object sender, RoutedEventArgs e)
    {
        if (_navigationServiceAssigned == false)
        {
            NavigationService.Navigating += NavigationService_Navigating;
            _navigationServiceAssigned = true;
        }
    }
