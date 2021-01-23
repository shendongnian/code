      Ping ping = new Ping();
      PingReply pingReply = ping.Send("ip address");
        
      if(pingReply.Status == IPStatus.Success)
        {
         // Connected 
        }
