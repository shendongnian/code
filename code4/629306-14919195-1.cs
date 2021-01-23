    public enum Message
    {
        HelloWorld,
        StackOverflow
    }
    public void DoSomething(Message message)
    {
        if (!Enum.IsDefined(typeof(Enum), message))
        {
            throw new ArgumentException("Invalid value: " + message, "message");
        }
        // Carry on
    }
