    Dictionary<string, int> ordering = new Dictionary<string, int> {
      { "Error", 1 },
      { "Pending", 2 },
      ...
    }
    
    var sortedList = myList.OrderBy(x => ordering[x.Status]);
