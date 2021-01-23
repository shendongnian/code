    // More or less the same solution as other answers
    var multiples1 = dictionary.GroupBy(p => p.Value)
                                .Where(g => g.Count() > 1)
                                .SelectMany(g => g);
    // A little bit faster because IsMultiple does not enumerate all values 
    // (Count() iterates to the end, which is not needed in this case).
    var multiples2 = dictionary.GroupBy(p => p.Value)
                                .Where(g => g.IsMultiple())
                                .SelectMany(g => g);
    // Easy to read
    var multiples3 = dictionary.Duplicates(p => p.Value);
