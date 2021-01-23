    // ...
    client = new TcpClient(); // Initialization of TcpClient
    CancellationToken ct = new CancellationToken(); // Required for "*.Task()" method
    if (client.ConnectAsync(this.ip, this.port).Wait(1000, ct)) // Connect with timeout as 1 second
    {
    	// ... transfer
        if (client != null) {
            client.Close(); // Close connection and dipose TcpClient object
            Console.WriteLine("Success");
            ct.ThrowIfCancellationRequested(); // Stop asynchronous operation after successull connection(...and transfer(in needed))
        }
    }
    else
    {
        Console.WriteLine("Connetion timed out");
    }
    // ...
