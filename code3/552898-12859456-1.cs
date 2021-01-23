    private async void Button_Click_1(object sender, RoutedEventArgs e) 
    {
         await GetResults();
    
         // Show dialog/UI element.  This code has been marshaled
         // back to the UI thread because the SynchronizationContext
         // was captured behind the scenes when
         // await was called on the previous line.
         ...
    
         // Check continue, if true, then continue with another async task.
         if (_continue) await ContinueToGetResultsAsync();
    }
    
    private bool _continue = false;
    private void buttonContinue_Click(object sender, RoutedEventArgs e)
    {
        _continue = true;
    }
    
    private async Task GetResults()
    { 
         // Do lot of complex stuff that takes a long time
         // (e.g. contact some web services)
      ...
    }
