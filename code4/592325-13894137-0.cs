    public static string ToCodePointNotation(char c)
    {
        return "U+" + ((int)c).ToString("X4");
    }
    Console.WriteLine(ToCodePointNotation('a')); //U+0061
