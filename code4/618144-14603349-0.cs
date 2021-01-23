    var keys = searchResults.Select(s => new { Key = s.SIT_PKey, SIT_HolderName = s.SIT_HolderName })
                            .ToList()
                            .Where(s => searchParams.AllowedHolders.Intersect(S.SIT_HolderName.Split(':')).Any())
                            .Select(s => s.Key)
                            .ToList();
    searchResult = searchResults.Where(s => test.Contains(s.SIT_PKey));
