    if (letter != '\0')
    {
           string substitute;
           pairs.TryGetValue(letter, out substitute);
           mystring = mystring.Replace(letter.ToString(), "");
           mystring += substitute;
    }
