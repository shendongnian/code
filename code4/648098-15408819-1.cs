    // Create the random instance only once.
    private static Random _Random = new Random();
    static void Main(string[] args)
    {
        var listOfCharacters = "abcdefghijklmnopqrstuvwxyz".ToList();
        var result = new StringBuilder();
        for (int i = 0; i < 20; i++)
        {
            // Consider creating the provider only once!
            var provider = new RNGCryptoServiceProvider();
            // The same is true for the byte array.
            var bytes = new byte[4];
            provider.GetBytes(bytes);
            var number = BitConverter.ToInt32(bytes, 0);
            var index = Math.Abs(number % listOfCharacters.Count);
            result.Append(listOfCharacters[index]);
        }
        Console.WriteLine(result.ToString());
        Console.ReadKey();
    }
