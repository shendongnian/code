    int i = 1;
    string subString = firstLine.SubString(0,1);
    while(CanBeParsedAsAKnownDataType(subString))
    {
        subString = fistLine.SubString(0,i);
        i++; 
    }
    
    if(i < firstLine.Length)
    {
        return firstLine[i];
    }
