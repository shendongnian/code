    public static void NullSafeInvoke(this EventHandler handler,
                                      object sender, EventArgs e)
    {
        if (handler != null)
        {
            handler(this, e);
        }
    }
