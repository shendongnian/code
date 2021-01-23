    public static IEnumerable<IPageNode> WithClonedParent(this IList<IPageNode> list)
    {
        var newParent = list.First().CloneParentIfSet();
        if (newParent)
        {
             yield return newParent;
        }
        foreach (var node in list)
        {
             yield return node;
        }
    }
