    public static TreeView TreeFromArray(Item[] arr)
    {
        var tv = new TreeView();
        var parents = new TreeNodeCollection[arr.Length];
        parents[0] = tv.Nodes;
        foreach (var item in arr)
        {
            parents[item.Depth + 1] = parents[item.Depth].Add(item.Name).Nodes;
        }
        return tv;
    }
