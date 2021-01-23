    using(var client = New OpenPop.Pop3.Pop3Client())
    {
       // Connect to the server
       client.Connect(Pop3Server, Pop3Port, false);
       // Authenticate towards the server
       client.Authenticate("usr", "pass", OpenPop.Pop3.AuthenticationMethod.UsernameAndPassword);
       // Get the number of messages in the inbox
       int messageCount = client.GetMessageCount();
    }
