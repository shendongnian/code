    public T Pop<T>()
    {
        var o = stack.Pop();
        return Convert.ChangeType(o, typeof(T));
    } 
    public void Push<T>(T item)
    {
        stack.Push(item);
    } 
