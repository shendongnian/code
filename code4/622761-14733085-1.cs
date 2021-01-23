    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        Dispatcher.RunAsync(
            CoreDispatcherPriority.Normal,
            () => myControl.Focus(FocusState.Keyboard));
    }
   
