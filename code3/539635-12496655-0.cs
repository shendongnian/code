      var input = ...;//Your cell content 
      var patternAlphabetic = @"([a-zA-Z])+";
      var patternNumeric = @"([0-9])+";
      var regex = new Regex(patternAlphabetic);
      var match = regex.Match(input);
      if (match.Success) 
      {
           System.Console.WriteLine("Alphabetic");
      }
      
       ..... 
