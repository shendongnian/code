    private void InitializeSignalR()
    {
        var hubConnection = new Connection("http://localhost:8084");
        var prestoHubProxy = hubConnection.CreateHubProxy("PrestoHub");
        prestoHubProxy.On<string>("OnSignalRMessage", (data) =>
            {
                MessageBox.Show(data);
            });
        hubConnection.Start();
    }
