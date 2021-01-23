    Dictionary<char, char> replacements = new Dictionary<char, char>();
    // populate replacements
    string str = "mystring";
    char []charArray = str.ToCharArray();
     
    for (int i = 0; i < charArray.Length; i++)
    {
        char newChar;
        if (replacements.TryGetValue(str[i], out newChar))
        charArray[i] = newChar;
    }
    string newStr = new string(charArray);
