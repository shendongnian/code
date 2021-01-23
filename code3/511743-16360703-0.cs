    var client = new ReactiveClient("127.0.0.1", 1055);
    // The parsing of messages is done in a simple Rx query over the receiver observable
    // Note this protocol has a fixed header part containing the payload message length
    // And the message payload itself. Bytes are consumed from the client.Receiver 
    // automatically so its behavior is intuitive.
    IObservable<string> messages = from header in client.Receiver.Buffer(4)
                                   let length = BitConverter.ToInt32(header.ToArray(), 0)
                                   let body = client.Receiver.Take(length)
                                   select Encoding.UTF8.GetString(body.ToEnumerable().ToArray());
    // Finally, we subscribe on a background thread to process messages when they are available
    messages.SubscribeOn(TaskPoolScheduler.Default).Subscribe(message => Console.WriteLine(message));
    client.ConnectAsync().Wait();
