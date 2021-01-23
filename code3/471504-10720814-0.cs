    bool IsValidInput(String input)
    {
        return input != null && input.All(c => IsValidLetter(c));
    }
    bool IsValidLetter(char c)
    {
        return (Char.IsNumber(c) || c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z');
    } 
