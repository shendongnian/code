    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Task.Run(() => Compute());
    }
    private void Compute()
    {
        // perform computation here
        Dispatcher.Invoke(CoreDispatcherPriority.Normal, ShowText, this, resultString);
    }
    private void ShowText(object sender, InvokedHandlerArgs e)
    {
        this.TextBlock.Text = (string)e.Context;
    }
