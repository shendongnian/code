    public static string TrimLettersLeft(this string input)
    { 
        int lastLetterIndex = -1;
        for (int i = input.Length - 1; i >= 0; i--)
        {
            if (Char.IsLetter(input[i]))
            {
                lastLetterIndex = i;
                break;
            }
        }
        
        if( lastLetterIndex == -1)
            return input;
        else
            return input.Substring(0, lastLetterIndex + 1);
    }
