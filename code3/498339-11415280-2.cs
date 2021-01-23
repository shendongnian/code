    List<int> numbers = { 1, 2, 3, 4 }; // This isn't valid.
    List<int> numbers = new List<int> { 1, 2, 3, 4 }; // Valid.
    // This is valid, but will NullReferenceException on Numbers
    // if NumberContainer doesn't "new" the list internally.
    var container = new NumberContainer()  
    {
        Numbers = { 1, 2, 3, 4 }
    };
