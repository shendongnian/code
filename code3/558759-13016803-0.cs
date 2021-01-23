    // Create topic
    string topicArn = client.CreateTopic(new CreateTopicRequest
    {
        Name = topicName
    }).CreateTopicResult.TopicArn;
    
    // Set display name to a friendly value
    client.SetTopicAttributes(new SetTopicAttributesRequest
    {
        TopicArn = topicArn,
        AttributeName = "DisplayName",
        AttributeValue = "StackOverflow Sample Notifications"
    });
    
    // Subscribe an endpoint - in this case, an email address
    client.Subscribe(new SubscribeRequest
    {
        TopicArn = topicArn,
        Protocol = "email",
        Endpoint = "sample@example.com"
    });
    
    // When using email, recipient must confirm subscription
    Console.WriteLine("Please check your email and press enter when you are subscribed...");
    Console.ReadLine();
    
    // Publish message
    client.Publish(new PublishRequest
    {
        Subject = "Test",
        Message = "Testing testing 1 2 3",
        TopicArn = topicArn
    });
    
    // Verify email receieved
    Console.WriteLine("Please check your email and press enter when you receive the message...");
    Console.ReadLine();
    
    // Delete topic
    client.DeleteTopic(new DeleteTopicRequest
    {
        TopicArn = topicArn
    });
