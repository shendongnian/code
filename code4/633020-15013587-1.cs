    string data = ...;
    JMessage message = JMessage.Deserialize(data);
    if (message.Type == typeof(Player))
    {
        Player player = message.Value.ToObject<Player>();
    }
    else if (message.Type == typeof(Enemy))
    {
        Enemy enemy = message.Value.ToObject<Enemy>();
    }
    //etc...
