         Regex numberFinder = new Regex("\\d+");
         Match numberMatch = numberFinder.Match(endParameter);
     
         // we assume that there is a match, because if there isn't the string isn't
         // correct, you should do some error handling here
         string matchedNumber = numberMatch.Value;
         int value = Int32.Parse(matchedValue); // we convert the string in to the number
         if(value == desiredValue)
         ...
