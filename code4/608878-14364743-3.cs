    using Windows.ApplicationModel.Core;
    using Windows.UI.Core;
    public static IAsyncAction ExecuteOnUIThread(DispatchedHandler action)
    {
      var priority = CoreDispatcherPriority.High;
      var dispatcher = CoreApplication.MainView.CoreWindow.Dispatcher;
      return dispatcher.RunAsync(priority, action);
    }
