    StringBuilder sb = new StringBuilder();
    
    string[] splitString = fTextSearch.Split(errorChars, StringSplitOptions.None);
    
    int numNewCharactersAdded = 0;
    foreach( string itm in splitString)
    {
       sb.Append(itm); //append string
       if (fTextSearch.Length > (sb.Length - numNewCharactersAdded))
       {
          sb.Append(fTextSearch[sb.Length - numNewCharactersAdded]); //append splitting character
          sb.Append(fTextSearch[sb.Length - numNewCharactersAdded - 1]); //append it again
          numNewCharactersAdded ++;
       }
    }
    
    string myBetterString = sb.ToString();
   
