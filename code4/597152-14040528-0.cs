    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        string strCodeTiers = string.Empty;
        if (NavigationContext.QueryString.TryGetValue("selectedItem",out strCodeTiers))
        {
             // Whatever
        }
    }
