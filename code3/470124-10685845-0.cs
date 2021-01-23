    private TEnum getEnumStringEnumType<TEnum>()
    {
        string userInputString = string.Empty;
        TEnum resultInputType;
        bool enumParseResult = false;
        while (!enumParseResult)
        {                
            userInputString = System.Console.ReadLine();
            enumParseResult = Enum.TryParse(userInputString, true, out resultInputType);
        }
        return resultInputType;
    }
