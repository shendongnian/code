    private static int MapPriority(string priority)
    {
      switch(priority.ToUpperInvariant())//skip the case bit if safe
      {
        case "HIGH":
          return 1;
        case "MEDIUM":
          return 2;
        case "LOW":
          return 3;
        default:
          return 4;
      }
    }
    
    var sorted = someCollection.OrderBy(i => MapPriority(i.PriorityProperty));
