        var result = (from searchResult in list
                     let title = searchResult.Title.ToLower()
                     let key_string = to_search.FirstOrDefault(ts => title.Contains(ts))
                     orderby key_string == null ? -1 : title.Split(new[] { key_string }, StringSplitOptions.None).Length descending
                     group searchResult by key_string into Group
                     select Group).OrderByDescending(grp => grp.Count()).ThenByDescending( grp => CountStringOccurrances(grp.Key, to_search));
    public static int CountStringOccurrences(string text, string[] pattern)
    {
        // Loop through all instances of the string 'text'.
        int count = 0;
        foreach (string itm in pattern)
        { 
           int i = 0;
           while ((i = text.IndexOf(itm, i)) != -1)
           {
              i += itm.Length;
              count++;
            }
        }
        return count;
    }
