    var dispatcher = Windows.UI.Core.CoreWindow.GetForCurrentThread().Dispatcher;
    api.AutenticarUsuarioFinalizado += (o, args) =>
    {
       dispatcher.RunAsync(DispatcherPriority.Normal, () => 
           ProgressBar.IsIndeterminate = false;
           ProgressBar.Visibility = Visibility.Collapsed;
       [...]
