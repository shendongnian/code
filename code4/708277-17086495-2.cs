    var treeCollection = new
    {
        id = 0,
        item = new List<object> // adding a sample value
        { 
            new // a sample set
            {
                id = 2, 
                text = "",
                parent = null
            }
        }
    }.Yield(); // an example to make it a collection. I assume it should be a collection
    foreach (var tree in treeCollection)
    {
        if (tree.id == 0)
            tree.item.Add(new
            {
                id = 1,
                text = "",
                parent = ""
            });
    }
    public static IEnumerable<T> Yield<T>(this T item)
    {
        yield return item;
    }
