    var predicateSearchText;
    List<string> separatedKeywords = keywords.Split(',').ToList();
    
    foreach (string s in separatedKeywords)
    {
       if (s.Length > 0)
       {
          predicateSearchText = PredicateBuilder.False<Asset>();
          string temp = s;
          predicateSearchText = predicateSearchText.Or(m => m.Notes.Contains(temp));
          predicateSearchText = predicateSearchText.Or(m => m.Description.Contains(temp));
          predicateSearchText = predicateSearchText.Or(m => m.DetailedDescription.Contains(temp));
          predicateSearchText = predicateSearchText.Or(asset => asset.Keywords.Contains(temp));
          predicateSearchText = predicateSearchText.Or(a => a.AssetFiles.Any(x => x.FileName.Contains(temp)));
          Query = Query.AsExpandable().Where(predicateSearchText);
       }
    }
