    private delegate void InlineDelegate();
    private void btnLogon_Click(object sender, RoutedEventArgs e)
    {
        lblInvalidLogon.Content = string.Empty;
        lblInvalidLogon.Dispatcher.Invoke(new InlineDelegate(() =>
        {
            //
            // Process to verify logon credentials...
            //
        }), System.Windows.Threading.DispatcherPriority.Background, null);
    }
