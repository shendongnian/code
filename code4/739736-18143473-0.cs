    public static IEnumerable<TempTable> PreorderForest(IEnumerable<TempTable> list)
    {
        var nodesByParent = list.GroupBy(x => x.ParentID.GetValueOrDefault(-1))
            .ToDictionary(xs => xs.Key, 
                          xs => xs.OrderBy(x => x.SortOrder).GetEnumerator());
        
        var stack = new Stack<IEnumerator<TempTable>>();
        stack.Push(nodesByParent[-1]);
        while (stack.Count > 0)
        {
            var nodes = stack.Peek();
            if (nodes.MoveNext())
            {
                yield return nodes.Current;
                IEnumerator<TempTable> children;
                if (nodesByParent.TryGetValue(nodes.Current.ID, out children))
                    stack.Push(children);
            }
            else
                stack.Pop();
        }
    }
