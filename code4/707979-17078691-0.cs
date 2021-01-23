    foreach (var play in w_server.OnlineConnections)
    {
        staytime = Server.tickcount.ElapsedMilliseconds;
        if (staytime > 1 * 20000 && play.Value.Map == "Rest")
        {
            w_server.Disconnect(play.Value.client.connection);
            play.Value.Map = "Village1";
            staytime = 0;
        }
    }
