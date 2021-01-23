        var connection = new HubConnection("http://localhost/");
        //Make proxy to hub based on hub name on server
        var myHub = connection.CreateHubProxy("ChatterBox");
        //Start connection
        connection.Start().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Console.WriteLine("Failed to start: {0}", task.Exception.GetBaseException());
            }
            else
            {
                Console.WriteLine("Success! Connected with client connection id {0}", connection.ConnectionId);
                
                // Do more stuff here
                
                connection.Send("Hello").ContinueWith(task =>
                {
                     .......
                });
            }
        });
