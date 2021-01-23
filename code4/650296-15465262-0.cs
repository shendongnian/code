    bool doReplace = false;
    char originalChar = letter1;
    char alternateChar = letter2;
    foreach (char c in key)
    {
        if (c == originalChar)
        {
            newKey.Append(alternateChar);
            doReplace = true;
        }
        else if (c == alternateChar && doReplace)
        {
            newKey.Append(originalChar);
        }
        else
        {
            newKey.Append(c);
        }
    }
