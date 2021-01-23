    // Get the max values in each slice
    var maxValues = slices.SelectMany(slice =>
        {
            var max = slice.Max(i => i.Value);
            return slice.Where(i => i.Value == max);
        })
        .ToArray();
    
