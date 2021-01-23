    // Define your collections
    var dates = new[]
                    {
                        new DateTime(2012, 1, 1), new DateTime(2012, 1, 2), new DateTime(2012, 1, 5),
                        new DateTime(2012, 1, 3)
                    };
    var ints = new[] {1,2,4,3};
            
    var result = dates
        .Select((d, i) => new {Date = d, Int = ints[i]}) // This joins the arrays based on index
        .OrderBy(o => o.Date) // Sort by whatever field you want
        .ToArray(); // Return the results an array
    // Extract just the dates
    dates = result.Select(o => o.Date).ToArray();
    // Extract just the ints
    ints = result.Select(o => o.Int).ToArray();
