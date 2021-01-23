    public void Start()
    {
      lock(this) 
      {
        if (running)
            return;
        myClients.Clear();
        listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 1234);
        listener.Start();
        listener.BeginAcceptTcpClient(AcceptClient, this);
        running = true;
      }
    }
    public void Stop()
    {
      lock(this)
      {
        if (!running)
            return;
        listener.Stop();
        foreach (MyClient client in myClients)
        {
            client.Finish();
        }
        myClients.Clear();
        running = false;
      }
    }
    public void AcceptClient(IAsyncResult ar)
    {
      lock(this)
      {
        MyClient client = new MyClient(this, ((TcpListener)ar.AsyncState).EndAcceptTcpClient(ar));
        myClients.Add(client);
        client.Go();
      }
    }
