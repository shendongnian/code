    public IEnumerator<T> GetEnumerator()
    {
        var node = front;
        while(node != null)
        {
            yield return node.data;
            node = node.next;
        }
    }
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
