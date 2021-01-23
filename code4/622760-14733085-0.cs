    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
    
            base.OnNavigatedTo(e);
             Dispatcher.RunAsync(CoreDispatcherPriority.High, () =>
                    {
                        myControl.Focus(Windows.UI.Xaml.FocusState.Keyboard)
                    });
    }
   
