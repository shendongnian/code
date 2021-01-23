    private void ClientSession(Socket clientSocket)
    {
        // Handle client session:
        // Send/Receive the data.
    }
    public void Listen()
    {
        Socket serverSocket = ...;
        while (true)
        {
            Console.WriteLine("Waiting for a connection...");
            var clientSocket = serverSocket.Accept();
            Console.WriteLine("Client has been accepted!");
            var thread = new Thread(() => ClientSession(clientSocket))
                {
                    IsBackground = true
                };
            thread.Start();
        }
    }
