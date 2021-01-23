    var searchText = "cat dog";
    var searchResult = list
      .Select(i => new { 
           Item = i, 
           Matched = searchText.Contains(i.Item.Title.ToUpper()),
           Count = list.Count(x => string.Compare(x.Title, i.Title, true) == 0)  // Add counter
      })
      .OrderByDescending(i => i.Matched)
      .ThenBy(i => i.Count)
      .ThenBy(i => i.Item.ID)
      .ToList()
