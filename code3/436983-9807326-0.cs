    foreach (int key in outerDictionary.Keys.OrderBy(i=>i))
    {
        // loop through the inner items by key
        var item = outerDictionary[key];
        foreach(int innerKey in item.Keys.OrderBy(i=>i))
        {
            ....
        }
    }
