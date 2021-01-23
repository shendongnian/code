    public static void Raise(this EventHandler source, object sender)
    {
        if (source != null)
        {
            source.Invoke(sender, new EventArgs());
        }
    }
    public static void Raise<T>(this EventHandler<T> source, object sender, T eventArgs)
        where T : EventArgs
    {
        if (source != null)
        {
            source.Invoke(sender, eventArgs);
        }
    }
