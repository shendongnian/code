    using(Pop3Client client = new Pop3Client())
    {
        // Connect to the server
        client.Connect("pop.gmail.com", 995, true);
        // Authenticate ourselves towards the server
        client.Authenticate("username@gmail.com", "password", AuthenticationMethod.UsernameAndPassword);
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
    }
