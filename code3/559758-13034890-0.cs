    var lookup = emptyArray.ToLookup(i => i);
    
    Console.WriteLine("The number of times ONE was inputed was {0}", lookup[1].Count());
    Console.WriteLine("The number of times TWO was inputed was {0}", lookup[2].Count());
    /// etc.
