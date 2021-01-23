    var characterMap = new Dictionary<char, int>();
    string regex = "^";
    int nextBackreference = 1;
    for(int i = 0; i < input.Length; i++)
    {
        char character = input[i];
        if(!characterMap.ContainsKey(character))
        {
            regex += "(.)";
            characterMap[character] = nextBackreference;
            nextBackreference++;
        }
        else
        {
            regex += (@"\" + characterMap[character]);
        }
    }
    regex += "$";
