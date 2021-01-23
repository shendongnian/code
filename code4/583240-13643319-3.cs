    var connection = new HubConnection("http://localhost/");
    //Make proxy to hub based on hub name on server
    var myHub = connection.CreateHubProxy("ChatterBox");
    //Start connection
    try 
    {
        await connection.Start();
        Console.WriteLine("Success! Connected with client connection id {0}", connection.ConnectionId);
    }
    catch(Exception ex) 
    {
        Console.WriteLine("Failed to start: {0}", ex.GetBaseException());
    }
    await connection.Send("Hello");
