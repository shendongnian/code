    private static void Write(string rest)
    {
        string result = ConvertStringToMorse(rest);
        Console.Write(result.PadRight(20));
        Console.WriteLine(rest);
    }
