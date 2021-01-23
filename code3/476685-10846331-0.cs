    public static List<Message> FetchAllMessages(string hostname, int port, bool useSsl, string username, string password)
    {
        // The client disconnects from the server when being disposed
        using (Pop3Client client = new Pop3Client())
        {
            // Connect to the server
            client.Connect(hostname, port, useSsl);
     
            // Authenticate ourselves towards the server
            client.Authenticate(username, password);
     
            // Get the number of messages in the inbox
            int messageCount = client.GetMessageCount();
     
            // We want to download all messages
            List<Message> allMessages = new List<Message>(messageCount);
     
            // Messages are numbered in the interval: [1, messageCount]
            // Ergo: message numbers are 1-based.
            // Most servers give the latest message the highest number
            for (int i = messageCount; i > 0; i--)
            {
                allMessages.Add(client.GetMessage(i));
            }
     
            // Now return the fetched messages
            return allMessages;
        }
    }
