    public static string UpperCaseStringSplitter(string stringToSplit)
    {
        var stringBuilder = new StringBuilder();
        for(int i = 0; i <stringToSplit.Length; i++)
        {
            char c = stringToSplit[i];
              
            if (Char.IsUpper(c) && i > 0)
                stringBuilder.Append(" " + c);
            else
                stringBuilder.Append(c);
        }
        return stringBuilder.ToString();
    }
