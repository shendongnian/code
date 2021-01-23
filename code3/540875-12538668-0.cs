    public IEnumerable<Message> GetMessage()
    {
        //do the peek and receive a single message
        yield return message;
    }
    
    //and then something like
    var producer = GetMessage().ToObservalble();
    // this is where your timeout goes
    var bufferedMessages = producer.BufferWithTime(TimeSpan.FromSeconds(3));
    var disp = bufferedMessages.Subscribe(messages =>
        {
            Console.WriteLine("You've got {0} new messages", messages.Count());
            foreach (var message in messages)
                Console.WriteLine("> {0}", message); // process messages here
        });
    disp.Dispose(); // when you no longer want to subscribe to the messages
