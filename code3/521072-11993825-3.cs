    static void Main(string[] args)
    {
        string input = "abcdefghijk";
        IEnumerable<char> inputArray = input.ToCharArray();
        IEnumerable<IEnumerable<char>> summary = permutations(inputArray);
    }
