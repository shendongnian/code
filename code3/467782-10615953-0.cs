    /// <summary>
    /// Remove any special character and return the first letters of all words
    /// </summary>
    /// <param name="str">String to retrieve the initials from</param>
    /// <returns></returns>
    public static string GetInitials(this string str)
    {
        if (string.IsNullOrEmpty(str))
            return str;
    
        var space = ' ';
        var previousWasSpace = true;
        var buffer = new char[str.Length];
        var index = 0;
        foreach (char c in str)
        {
            if (c == space)
            {
                previousWasSpace = true;
            }
            else if (previousWasSpace && char.IsLetterOrDigit(c))
            {
                previousWasSpace = false;
                buffer[index] = c;
                index++;
            }
        }
    
        return new string(buffer, 0, index);
    }
