    private static TEnum getEnumStringEnumType<TEnum>()
        where TEnum : struct
    {
        string userInputString = string.Empty;
        TEnum resultInputType = default(TEnum);
        bool enumParseResult = false;
        while (!enumParseResult)
        {                
            userInputString = System.Console.ReadLine();
            enumParseResult = Enum.TryParse(userInputString, true, out resultInputType);
        }
        return resultInputType;
    }
