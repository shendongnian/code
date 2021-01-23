    List<SearchResult> list = new List<SearchResult>() { 
        new SearchResult(){ID=1,Title="Cat"},
        new SearchResult(){ID=2,Title="dog"},
        new SearchResult(){ID=3,Title="Tiger"},
        new SearchResult(){ID=4,Title="Cat"},
        new SearchResult(){ID=5,Title="cat"},
        new SearchResult(){ID=6,Title="dog"},
    };
    var to_search = new[] { "cat", "dog" };
    var result = list.Where(sr => to_search.Any(ts => String.Compare(ts, sr.Title, StringComparison.OrdinalIgnoreCase) == 0))
                     .GroupBy(sr => sr.Title.ToLower())
                     .OrderByDescending(g => g.Count());
    foreach (var group in result)
        foreach (var element in group)
            Debug.WriteLine(String.Format("ID={0},Title={1}", element.ID, element.Title));
