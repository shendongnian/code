    public static void Raise(this EventHandler handler, object sender)
    {
      if (handler != null)
        handler(sender, EventArgs.Empty);
    }
    // And then...
    TheEvent.Raise(this);
