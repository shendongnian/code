     IPAddress add = IPAddress.Loopback; /// Reuturns local Ip Address
     PingReply reply = ping.Send(add);
     if (reply.Status == IPStatus.Success)
     {
        Console.WriteLine("Pinging with server");
        Console.WriteLine("Press any key to continue");
        Console.ReadKey(true);
      }
