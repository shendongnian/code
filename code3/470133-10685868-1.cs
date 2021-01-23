    private T getEnumStringEnumType<T>() where T : struct, new()
    {
        string userInputString = string.Empty;
        T resultInputType;
        bool enumParseResult = false;
        while (!enumParseResult)
        {                
            userInputString = System.Console.ReadLine();
            enumParseResult = Enum.TryParse<T>(userInputString, out resultInputType);
        }
    }
