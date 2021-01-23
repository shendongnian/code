    var dispatcher = Windows.UI.Core.CoreWindow.GetForCurrentThread().Dispatcher;
    api.AutenticarUsuarioFinalizado += (o, args) =>
    {
       Dispatcher.RunAsync(DispatcherPriority.Normal, () => 
           ProgressBar.IsIndeterminate = false;
           ProgressBar.Visibility = Visibility.Collapsed;
       [...]
