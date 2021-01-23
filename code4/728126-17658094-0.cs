    class MyClient
    {    
      TaskCompletionSource<object> navigation;
      WebBrowser webBrowser;
      public MyClient(WebBrowser wb)
      {
        navigation = new TaskCompletionSource<object>();
        webBrowser = wb;    
        webBrowser.DocumentCompleted += (sender, e) =>
        {
          if (e.Url == webBrowser.Url)
          {
            navigation.TrySetCompleted(null);
          }
        };
      }
      public Task LogIn(string login, string password)
      {
        navigation = new TaskCompletionSource<object>();
        webBrowser.Navigate(url);
        return navigation.Task;
      }
    }
