       public bool CanConnect()
       {
        var ping = new Ping();
        var reply = ping.Send("search.yahoo.com");
        return reply.Status == IPStatus.Success;
       }
