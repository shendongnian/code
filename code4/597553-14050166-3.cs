    Ping ping = new Ping();
    ping.PingCompleted += (sender, e) => 
    {
        if (e.Reply.Status == IPStatus.Success)
        {
            // yay
        }
    };
    ping.SendAsync("127.0.0.1", 3000, null);
