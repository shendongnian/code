    string input "..";
    HashSet<char> wantedCharactersSet = new HashSet<char>(wantedCharacters);
    for (int i = 0; i < input.Length; i++)
    {
        if (!wantedCharactersSet.Contains(input[i]))
            input[i] = placeholderChar;
    }
