    // In your sub-class.
    public void PostMessage(string message)
    {
        base.PostMessage(message, DateTime.Now);
    }
