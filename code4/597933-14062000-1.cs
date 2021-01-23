    var result = summary
        // get all necessary data, including filter that matched given item
        .Select(Item => new
            {
                Item,
                Filter = searches.FirstOrDefault(f => f.CodeID == Item.CodeID)
            })
        // get rid of those without matching filter
        .Where(i => i.Filter != null)
        // this is your occurrences filtering
        .Where(i => i.Item.Occurences >= i.Filter.MinOccurences
            && i.Item.Occurences <= i.Filter.MaxOccurences)
        // and finally extract original events IDs
        .SelectMany(i => i.Item.Items)
        .Select(i => i.ID);
