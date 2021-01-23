    var uri = Application.Current.Host.Source.GetComponents(UriComponents.Scheme | UriComponents.HostAndPort, UriFormat.Unescaped);
     _hubConnection = new HubConnection(uri);
     var hub = _hubConnection.CreateProxy("stuffhub");
     hub.On<Stuff>("Stuff", message => DoStuff());
     _hubConnection.Start().ContinueWith(task => 
     {
         if(task.IsFaulted) {
             Debug.WriteLine("Error starting -" + task.Exception.GetBaseException());
         }
     });
