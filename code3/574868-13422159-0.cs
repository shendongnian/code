    var codequery = ...
                    select new HomeSearchViewModel
                    {
                        AlphaGroupCode = c.FirstOrDefault()
                        AlphasCodes = g
                    };
    foreach (var q in queryNew)
    {
        q.AlphaCodes = codequery.Where(x => x.AlphaGroupCode == q.AlphaGroupCode)
                                .FirstOrDefault()
                                .AlphaCodes;
    }
