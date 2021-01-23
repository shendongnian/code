    Ping pingSender = new Ping();
    PingOptions options = new PingOptions();
    
    // Default Time To Live (TTL) but don't fragment request.
    options.DontFragment = true;
    
    // Create a buffer of 32 Bytes:
    string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    byte[] buffer = Encoding.ASCII.GetBytes(data);
    
    // Timeout
    int timeout = 120;
    
    // Ping and Request Reply
    pingReply reply = pingSender.Send(args[0], timeout, buffer, options);
    if(reply.Status == IPStatus.Success)
    {
         Console.WriteLine("Address: {0}, reply.Address.ToString());
         Console.WriteLine ("RoundTrip time: {0}", reply.RoundtripTime);
         Console.WriteLine ("Time to live: {0}", reply.Options.Ttl);
         Console.WriteLine ("Don't fragment: {0}", reply.Options.DontFragment);
         Console.WriteLine ("Buffer size: {0}", reply.Buffer.Length); 
    }    
