    async void MainPage_Loaded(object sender, RoutedEventArgs args)
    {
        await System.Threading.Tasks.Task.Delay(1000);
        var allowed = await Windows.ApplicationModel.Background
            .BackgroundExecutionManager.RequestAccessAsync();
        System.Diagnostics.Debugger.Break();
    }
