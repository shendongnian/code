    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        CheckForUser();
        if (UserExists == false)
            Dispatcher.RunAsync(CoreDispatcherPriority.Normal, 
                                () => this.Frame.Navigate(typeof(NewUser)));
    }
