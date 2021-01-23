    public void DoSomething(Message message)
    {
        if (!message.IsNamedValue()) // Extension method
        {
            throw new ArgumentException("Invalid value: " + message, "message");
        }
        // Carry on
    }
