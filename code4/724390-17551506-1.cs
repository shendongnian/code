       public bool CanConnect(string addressToTest)
       {
        var ping = new Ping();
        var reply = ping.Send(addressToTest);
        return reply.Status == IPStatus.Success;
       }
