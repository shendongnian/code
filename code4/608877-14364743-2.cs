    async void NetworkInformation_NetworkStatusChanged(object sender)
    {
      var isConnected = CheckInternetAccess();
      await ExecuteOnUIThread(() =>
      {        
        if (!isConnected && this.Frame != null)
          this.Frame.Navigate(typeof(ConnectionLostPage));
      });
    }
     
