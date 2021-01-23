    List<???> selectedItems = new List<???>();
    for (var i = 0; i < remainingIndices.Count; i++)
    {
        var probability = pixelsToAdd / (float)(remainingIndices.Count - i);
        if (Random.NextDouble() <= probability)
        {
            selectedItems.Add(items[i]);
            pixelsToAdd--;
        }
    }
