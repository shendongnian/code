    if (string.IsNullOrWhiteSpace(stringToSplit)) return stringToSplit;
    var stringBuilder = new StringBuilder();
    for (int i = 0; i < stringToSplit.Length; i++)
    {
        if (Char.IsUpper(stringToSplit[i]))
        { 
            stringBuilder.Append(" ");
        }
        stringBuilder.Append(stringToSplit[i]);
    }
    return stringBuilder.ToString().Trim();
