    var source = new Subject<long>();
    
    var host = new Host(source);
    var client1 = new Client(host.Messages);
    var client2 = new Client(host.Messages);
    var client3 = new Client(host.Messages);
    
    source.OnNext(1); // assuming each of these is an IMessage
    source.OnNext(2);
    source.OnNext(3);
