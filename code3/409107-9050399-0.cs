    List<string> str = new List<string>{ "a", "h", "q", "z", "b", "d" };
    List<List<string>> combinations = combine(str.OrderBy(s=>s).ToList());
    
    List<List<string>> combine(List<string> items)
    {
        List<List<string>> all = new List<List<string>>();
        // For each index item in the items array
        for(int i = 0; i < items.Length; i++)
        {
            // Create a new list of string
            List<string> newEntry = new List<string>();
            // Take first i items
            newEntry.AddRange(items.Take(i));
            // Concatenate the remaining items
            newEntry.Add(String.concat(items.Skip(i)));
            // Add these items to the main list
            all.Add(newEntry);
            // If this is not the last string in the list
            if(i + 1 < items.Length)
            {
                // Process sub-strings
                all.AddRange(combine(items.Skip(i + 1).ToList()));
            }
        }
        return all;
    }
