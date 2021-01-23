    var treeCollection = new
    {
        id = 0,
        item = new List<object> // adding a sample value
        { 
            new // a sample set
            {
                id = 2, 
                text = "",
                parent = null // some object
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
                parent = null
            });
    }
    public static IEnumerable<T> Yield<T>(this T item)
    {
        yield return item;
    }
