    public void PrintVar(string fieldName)
    {
        Console.WriteLine(GetType().GetField(fieldName,
            BindingFlags.NonPublic | BindingFlags.Instance).GetValue(this));
    }
    
