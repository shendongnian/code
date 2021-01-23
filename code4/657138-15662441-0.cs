    private static INodeCollection NodesLookUp(string path, int maxLevel)
    {
        var shareCollectionNode = new ShareCollection(path);
        if (maxLevel > 0)
        {
            foreach (var directory in Directory.GetDirectories(shareCollectionNode.FullPath))
            {
                shareCollectionNode.AddNode(NodesLookup(directory, maxLevel-1));
            }
        }
        return shareCollectionNode;
    }
