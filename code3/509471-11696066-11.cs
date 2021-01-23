    public virtual bool Contains(T item)
    {
      return this.FindNode(item) != null;
    }
    internal virtual SortedSet<T>.Node FindNode(T item)
    {
      for (SortedSet<T>.Node node = this.root; node != null; {
        int num;
        node = num < 0 ? node.Left : node.Right;
      }
      )
      {
        num = this.comparer.Compare(item, node.Item);
        if (num == 0)
          return node;
      }
      return (SortedSet<T>.Node) null;
    }
