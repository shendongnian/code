    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        
        while (this.NavigationService.BackStack.Any())
        {
            this.NavigationService.RemoveBackEntry();
        }
    }
