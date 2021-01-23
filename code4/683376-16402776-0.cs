    public static event EventHandler<PlayerMovedEventArgs> PlayerMoved;
    // Often, you'll have a method to raise the event:
    public static void OnPlayerMoved(PlayerMovedEventArgs args)
    {
        var handler = PlayerMoved;
        if (handler != null)
            handler(null, args);
    }
