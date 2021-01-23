    async Task TestMethod()
    {
        string connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");
        QueueClient Client = QueueClient.CreateFromConnectionString(connectionString, "TestQueue");
        var message = await Client.ReceiveAsync();
    }
