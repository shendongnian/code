    // Get the max values in each slice
    var maxValues = slices.SelectMany(slice =>
        slice.Where(i => i.Value == slice.Max(j => j.Value)))
        .ToArray();
    
