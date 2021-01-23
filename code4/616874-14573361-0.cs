    using SignalR.Client.Hubs;
    var hubConnection = new HubConnection(HUB_URL);
    var hub = hubConnection.CreateProxy(HUB_NAME);
    Console.WriteLine("Starting connection");
    await hubConnection.Start();
    Console.WriteLine("Connected");
    var start = DateTime.Now;
    var question = new Question
    {
        Text = "text message",
        Time = start.ToString("d")
    }
    };
    await hub.Invoke("Ask", question);
    hubConnection.Stop();
