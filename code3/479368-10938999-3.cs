    private void postWithParamsClient_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
    {
      Dispatcher.BeginInvoke(() => {
        if (e.Error == null)
          MessageBox.Show("WebClient: " + e.Result);
        else
          MessageBox.Show("WebClient: " + e.Error.Message);
      });
    }
