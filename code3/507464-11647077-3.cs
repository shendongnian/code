    int amountToAmend = 200;
    // create sample data with 600 integers
    List<int> flattened = Enumerable.Range(1, 600).ToList();  
    // group these 600 numbers into 3 nested lists with each 200 integers
    List<List<int>> unflattened = flattened
        .Select((i, index) => new { i, index })
        .GroupBy(x => x.index / amountToAmend)
        .Select(g => g.Select(x => x.i).ToList())
        .ToList();
