    var server = new NamedPipeServer<SomeClass>("MyServerPipe");
    server.ClientConnected += delegate(NamedPipeConnection<SomeClass> conn)
        {
            Console.WriteLine("Client {0} is now connected!", conn.Id);
            conn.PushMessage(new SomeClass { Text: "Welcome!" });
        };
    
    server.ClientMessage += delegate(NamedPipeConnection<SomeClass> conn, SomeClass message)
        {
            Console.WriteLine("Client {0} says: {1}", conn.Id, message.Text);
        };
    
    server.Start();
