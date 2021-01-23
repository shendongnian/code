    string[] arrayToParse = {2, G, R, G, B};
    List<String> parsedList = new List<String>
    foreach(String sToParse in arrayToParse)
    {
      if (parsedList.Count <= 0)
         parsedList.Add(sToParse);
      else
      foreach(String sInParsedList in parsedList)
      {
         if(sToParse == sInParsedList)
            sInParsedList += sToParse;
 
         else
         parsedList.Add(sToParse);
      }
     string[] parsedArray = parsedList.ToArray();
       
      
    
      
