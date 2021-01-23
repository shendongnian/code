    private static readonly String[] ValidValues = {"Hello World", "stackoverflow"};
    public void DoSomething(string text)
    {
        if (!ValidValues.Contains(text))
        {
            throw new ArgumentException("Invalid value: " + text, "text");
        }
        // Carry on
    }
