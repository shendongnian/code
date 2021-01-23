    [ConditionalAttribute("DEBUG")]
    public void WriteOnlyInDebug(string message)
    {
        Console.WriteLine(message);
    }
