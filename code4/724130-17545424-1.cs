    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        string parameter;
        if (this.NavigationContext.QueryString.ContainsKey("param"))
        {
            parameter = this.NavigationContext.QueryString["param"];
            GoToOSSettigsPage(parameter);
        }
    }
