    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        string guid = string.Empty;
        if (NavigationContext.QueryString.TryGetValue("guid", out guid))
        {
           //guid exists
           if(NavigationService.CanGoBack)
              NavigationService.RemoveBackEntry();
        }
    }
