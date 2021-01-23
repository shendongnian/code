    var keys = searchResults.Select(s => new { Key = s.SIT_PKey, SIT_HolderName = s.SIT_HolderName })
                            .ToList()
                            .Where(s => searchParams.AllowedHolders.Intersect(s.SIT_HolderName.Split(':')).Any())
                            .Select(s => s.Key)
                            .ToList();
    searchResult = searchResults.Where(s => keys.Contains(s.SIT_PKey));
