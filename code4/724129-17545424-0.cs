    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        string param;
        if (this.NavigationContext.QueryString.ContainsKey("param"))
        {
            productID = this.NavigationContext.QueryString["ProductId"];
            GoToOSSettigsPage(param);
        }
    }
