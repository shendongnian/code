    Deployment.Current.Dispatcher.BeginInvoke(() => {
      var result = MessageBox.Show(message, title, MessageBoxButton.OKCancel);
      OnMessageBoxComplete(result);
    });
       
    void OnMessageBoxComplete(MessageBoxResult result) { 
      ...
    }
