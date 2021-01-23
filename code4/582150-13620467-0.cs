    private void ResponseCallback(IAsyncResult asyncResult)
    {
       ...
       this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
       {
          info.Text = responseString;
       });
    }
