    var possibleGuids = myString.Split("|;#".ToCharArray(), 
                                       StringSplitOptions.RemoveEmptyEntries);
    Guid g;
    foreach(var poss in possibleGuids)
    {
      if(Guid.TryParse(poss, out g))
      {
          // g contains a guid!
      }
    }
