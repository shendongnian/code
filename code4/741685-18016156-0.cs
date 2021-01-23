    protected virtual void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.NavigationMode != System.Windows.Navigation.NavigationMode.Back)
        {
             this.Number = this.NavigationContext.QueryString["Number"];
        }
    }
