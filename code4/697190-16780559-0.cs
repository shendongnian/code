    public IEnumerable<ReferenceNode<TItem, TKey>> AllBellow(ReferenceNode<TItem, TKey> node)
    {
        if (/*some codition that tells me that i can return this*/)
        {
            yield return node;
        }
        else 
        {
            foreach (var child in node.Children.Reverse())
            {
                foreach (var grandChild in AllBellow(child))
                {
                    yield return grandChild;
                }
            }
        }
    }
