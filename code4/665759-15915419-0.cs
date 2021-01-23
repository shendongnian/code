            var hubConnection = new HubConnection("http://url/");
            hubConnection.TraceWriter = Console.Out;
            hubConnection.Closed += () => Console.WriteLine("hubConnection.Closed");
            hubConnection.ConnectionSlow += () => Console.WriteLine("hubConnection.ConnectionSlow");
            hubConnection.Error += (error) => Console.WriteLine("hubConnection.Error {0}: {1}", error.GetType(), error.Message);
            hubConnection.Reconnected += () => Console.WriteLine("hubConnection.Reconnected");
            hubConnection.Reconnecting += () => Console.WriteLine("hubConnection.Reconnecting");
            hubConnection.StateChanged += (change) => Console.WriteLine("hubConnection.StateChanged {0} => {1}", change.OldState, change.NewState);
