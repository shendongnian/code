    for(int i=0; i<stringToSplit; i++)
    {
        if (i > 0 && Char.IsUpper(stringToSplit[i]))
            stringBuilder.Append(" ").Append(stringToSplit[i]);
        else
            stringBuilder.Append(stringToSplit[i]);
    }
