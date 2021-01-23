    var ping = new Ping();
    ping.PingCompleted += (sender, eventArgs) =>
    {
        // eventArgs.Reply.Address
        // eventArgs.Reply.Status
    };
    ping.SendAsync(ip, etc.);
