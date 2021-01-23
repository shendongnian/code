    var list = ...; // Get hold of the whole list.
    var sortedElements = list.Where((value, index) => index % 3 != 2)
                             .OrderBy(x => x)
                             .ToList();
    for (int i = 0; i < sortedElements.Count; i++)
    {
        int index = (i / 2) * 3 + i % 2;
        list[index] = sortedElements[i];
    }
