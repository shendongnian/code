    using (NetworkStream clientStream = tcpClient.GetStream())
    using (StreamReader reader = new StreamReader(clientStream))
    {
        while (true)
        {
            message = reader.ReadLine();
            if (message == null)
            {
                LogToConsole(clientEndPoint, "Client has disconnected");
                break;
            }
            messageCounter++;
            LogToConsole(clientEndPoint, String.Format(" >> [{0}] Message received: {1}", messageCounter, message));
        }
    }
