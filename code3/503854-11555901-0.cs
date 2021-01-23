    var publisher = new ZmqPublishSocket {
        Identity = Guid.NewGuid().ToByteArray(),
        RecoverySeconds = 10
    };
     
    publisher.Bind( address: "tcp://127.0.0.1:9292" );
     
    // Add a subscriber.
    var subscriber = new ZmqSubscribeSocket();
     
    subscriber.Connect( address: "tcp://127.0.0.1:9292" );
    subscriber.Subscribe( prefix: "" ); // subscribe to all messages
     
    // Add a handler to the subscriber's OnReceive event
    subscriber.OnReceive += () => {
        String message;
        subscriber.Receive( out message, nonblocking: true );
     
        Console.WriteLine( message );
    };
     
    // Publish a message to all subscribers.
     
    publisher.Send( "Hello world!" );
