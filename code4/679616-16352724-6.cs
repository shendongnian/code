    while (true)
    {
        resetEvent.Reset();
        Console.WriteLine("|| Waiting for connection");
        clientListener.BeginAccept(new AsyncCallback(AcceptConnection), clientListener);
        resetEvent.WaitOne();
    }
