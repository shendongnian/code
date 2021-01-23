    Uri uri = new Uri("localhost:2345/API/GetUsers");
    WebClient wbclient = new WebClient(); 
    wbclient.DownloadStringAsync(uri);
    wbclient.DownloadStringCompleted += (o, eargs) =>
        {
          if (eargs.Error == null)
          {
            var UserList = JsonConvert.DeserializeObject<List<User>>(e.Result);
            // bind users to ur itemsControl
          }
          else
            Dispatcher.BeginInvoke(() => MessageBox.Show("failed !"));
                        
        };
     
