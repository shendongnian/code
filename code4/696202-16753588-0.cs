    private void InitializeSignalR()
    {
    	var hubConnection = new HubConnection("http://localhost:8084");
    	var prestoHubProxy = hubConnection.CreateHubProxy("PrestoHub");
    	
    	// Bind the "OnSignalRMessage" to a function
    	prestoHubProxy.On<string>("OnSignalRMessage", (data) => {
    		MessageBox.Show(data);
    	});
    	
    	hubConnection.Start();	
    }
