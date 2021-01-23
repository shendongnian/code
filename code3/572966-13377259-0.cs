    long numberValue;
    // First parse the string value into a long
    bool isParsed  = Int64.TryParse(stringValue, numberValue);
    
    // Check to see that the value was parsed correctly
    if(isParsed)
    {
        int index = Array.IndexOf(numberArray, numberValue);
        // Check to see if the value actually even exists in the array
        if(index != -1)
        {
            char c = charArray[index];
            // ...
        }
    }
