    long numberValue;
    // First parse the string value into a long
    bool isParsed  = Int64.TryParse(stringValue, out numberValue);
    
    // Check to see that the value was parsed correctly
    if(isParsed)
    {
        // Find the index of the value
        int index = Array.IndexOf(numberArray, numberValue);
        // Check to see if the value actually even exists in the array
        if(index != -1)
        {
            char c = charArray[index];
            // ...
        }
    }
