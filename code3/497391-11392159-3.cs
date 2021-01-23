    List<SearchResult> list = new List<SearchResult>() 
    { 
       new SearchResult { Description = "JCB Excavator - ECU P/N: 728/35700" },
       new SearchResult { Description = "Geo Prism 1995 - ABS #16213899" },
       new SearchResult { Description = "Geo Prism 1995 - ABS #16213899" },
       new SearchResult { Description = "Geo Prism 1995 - ABS #16213899" },
       new SearchResult { Description = "Wie man BBA reman erreicht" },
       new SearchResult { Description = "this test JCB" },
       new SearchResult { Description = "Ersatz Airbags, Gurtstrammer und Auto Körper Teile" }            
       };
       var wordsToFind = "Geo JCB".Split();
       var values = list.Select(x => new { SearchResult = x, Count = x.Description.Split(' ')
                                                 .Where(c => wordsToFind .Contains(c)).Count() })
                        .OrderByDescending(x => x.Count)
                        .Select(x => x.SearchResult);
