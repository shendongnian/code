       public bool CanConnect()
       {
        var ping = new Ping();
        var reply = ping.Send("http://search.yahoo.com");
        return reply.Status == IPStatus.Success;
       }
