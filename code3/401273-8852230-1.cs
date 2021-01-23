    // Create a dictionary to hold key-value pairs of words and counts
    IDictionary<string, int> counts = new Dictionary<string, int>();
    // Iterate over each word in your list
    foreach (string value in list)
    {
        // Add the word as a key if it's not already in the dictionary, and
        // initialize the count for that word to 0.
        if (!counts.ContainsKey(value))
            counts.Add(value, 0);
        
        // Increment (+1) the count for each word encountered
        counts[value]++; 
    }
    // Loop through the dictionary results to print the results
    foreach (string value in counts.Keys)
    {
        System.Diagnostics.Debug
            .WriteLine("\"{0}\" occurs {1} time(s).", value, counts[value]);
    }
