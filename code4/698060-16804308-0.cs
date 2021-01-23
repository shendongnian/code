    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
        this.AdRotatorControl.Invalidate();
        base.OnNavigatedTo(e);
        // Load up the data using a query string in case of tombstoning
        string profileIdStr, conversionIdStr;
        NavigationContext.QueryString.TryGetValue("ProfileId", out profileIdStr);
        int profileId = System.Int32.Parse(profileIdStr);
        NavigationContext.QueryString.TryGetValue("ConversionId", out conversionIdStr);
        ConversionId conversionId = (ConversionId)Enum.Parse(typeof(ConversionId), conversionIdStr, true);
        if (App.VM.GroupedConversions == null
            || !App.VM.SkipLoadConversionPageData)
        {
            await App.VM.LoadConversionsPageDataAsyncTask(profileId, conversionId);
        }
        if (App.VM.SkipLoadConversionPageData)
            App.VM.SkipLoadConversionPageData = false;
    }
