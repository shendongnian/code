    int index = 3;
    int bracketCount = 1;
    
    for(int i = index + 1; i < tokenlist.Count; i++)
    {
        if(tokenList[i] == "]")
        {
            bracketCount--;
        }
        if(tokenList[i] == "[")
        {
            bracketCount++;
        }
        if(bracketCount == 0)
        {
            index = i;
            break;
        }
    }
