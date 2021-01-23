    StringBuilder sb = new StringBuilder();
    
    string[] splitString = fTextSearch.Split(errorChars, StringSplitOptions.None);
    
    int numNewCharactersAdded = 0;
    char fillChar = ' ';
    foreach( string itm in splitString)
    {
       sb.Append(itm); //append string
       if (fTextSearch.Length > (sb.Length - numNewCharactersAdded))
       {
          sb.Append(fillChar);
          sb.Append(fTextSearch[sb.Length - numNewCharactersAdded - 1]); //append splitting character
          sb.Append(fillChar);
          numNewCharactersAdded += 2;
    }
    
    string myBetterString = sb.ToString();
   
