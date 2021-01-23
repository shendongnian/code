    private IEnumerable<T> _list;
    public virtual List<T> Find(Func<T, bool> predicate)
    {
        T myObj = _list.FirstOrDefault(predicate);
        return GetEntities(myObj);
    }
