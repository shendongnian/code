    public string CustomFormatter(string input)
    {
        if (input.Length < 5) return input;
         char[] characters = input.ToCharArray();
        for (int i = characters.Length - 5; i <= 0; i--)
        {
            characters[i] = 'X';
        }
       return new string(characters);
    }
