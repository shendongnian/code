    Ping pingSender = new Ping ();
    byte[] data = Encoding.ASCII.GetBytes ("test");
    int timeout = 100;
    PingReply reply = pingSender.Send("127.0.0.1", timeout, data);
    if (reply.Status == IPStatus.Success)
    {
    	Console.WriteLine("Address: {0}", reply.Address.ToString());
    	Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
    	Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
    }
