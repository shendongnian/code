      Ping ping = new Ping();
      //PingReply reply= ping.Send("ip address");
      PingReply reply= ping.Send("www.google.com");
        
      if(reply.Status == IPStatus.Success)
        {
         // Connected 
           Console.WriteLine ("Address: {0}", reply.Address.ToString ());
           Console.WriteLine ("RoundTrip time: {0}", reply.RoundtripTime);
           Console.WriteLine ("Time to live: {0}", reply.Options.Ttl);
           Console.WriteLine ("Don't fragment: {0}", reply.Options.DontFragment);
           Console.WriteLine ("Buffer size: {0}", reply.Buffer.Length);
        }
      else
        {
          Console.WriteLine (reply.Status);
        }
