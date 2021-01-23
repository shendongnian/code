    System.Windows.Deployment.Current.Dispatcher.BeginInvoke(() =>
    {
        Screen.Width = (int) System.Windows.Application.Current.Host.Content.ActualWidth;
        Screen.Height = (int) System.Windows.Application.Current.Host.Content.ActualHeight;
    });
