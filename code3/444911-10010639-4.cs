    bool IsBracket(char character)
    {
        return (character == '(' | character == ')');
    }
    
    bool IsNumeric(char character)
    {
        return "0123456789".Contains(character);
        // or return Char.IsNumber(character);
    }
    
    bool IsLetter(char character)
    {
        // see why this is NOT prone to fail just because 'a' is greater than 'Z' in C#?
        return (character >= 'a' & character <= 'z') |
            (character >= 'A' & character <= 'Z');
    
        // or return Regex.IsMatch(character.ToString(), "[a-zA-Z]", RegexOptions.None);
        // or return Char.IsLetter(character);
    }
    
    // now you can implement:
    bool IsRecognized(char character)
    {
        return IsBracket(character) | IsNumeric(character) | IsLetter(character);
    }
