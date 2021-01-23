    // Check to see if we can find the 1st char to replace in the string
    bool doReplace = key.Any(c => c == originalChar);
    
    if (doReplace)
    {
        foreach (char c in key)
        {
            if (c == originalChar)
            {
                newKey.Append(alternateChar);
            }
            else if (c == alternateChar)
            {
                newKey.Append(originalChar);
            }
            else
            {
                newKey.Append(c);
            }
        }
    }
    else
    {
        newKey = key;
    }
    this.textBox4.Text = newKey.ToString();
