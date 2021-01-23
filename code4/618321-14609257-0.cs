    public static IEnumerable<char> ReadKeys()
    {
        while (true)
        {
            yield return Console.ReadKey().KeyChar;
        }
    }
