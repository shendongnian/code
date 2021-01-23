    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.NavigationMode != NavigationMode.New)
        {
            throw new Exception("exit");
        }
        string parameter;
        if (this.NavigationContext.QueryString.ContainsKey("param"))
        {
            parameter = this.NavigationContext.QueryString["param"];
            GoToOSSettigsPage(parameter);
        }
    }
