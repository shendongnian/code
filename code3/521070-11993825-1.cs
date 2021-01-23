    static void Main(string[] args)
    {
        string input = "abcdefghijk";
        List<string> inputs = new List<string>();
        inputs.Add(input);
        var summary = permutations<string>(inputs);
    }
