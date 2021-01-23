    string input = "XXXX-NNNN-A/N";
    char[] seperators = new[] { '/', '-' };
    Dictionary<int, char> positions = new Dictionary<int,char>();
    for (int i = 0; i < input.Length; i++)
        if (seperators.Contains(input[i]))
            positions.Add(i + 1, input[i]);
    foreach(KeyValuePair<int, char> pair in positions)
        Console.WriteLine(pair.Key + " \"" + pair.Value + "\"");
