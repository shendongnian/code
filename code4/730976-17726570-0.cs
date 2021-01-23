    private IEnumerable<EntityObject> GetFilteredData(Type entityType, SortedList<string, string> filterList, List<int> weeks)
    {
        var method = typeof(<class>).GetMethod(GetFilteredDataImpl);
        var generic = method.MakeGenericMethod(entityType);
        return (IEnumerable<EntityObject>)generic.Invoke(this, new[] { filterList, weeks });
    }
    
    private IEnumerable<T> GetFilteredDataImpl<T>(SortedList<string, string> filterList, List<int> weeks)
        where T : EntityObject
    {
        var data = _modelContext.CreateObjectSet<T>().AsExpandable();
          // do more filtering and then call .ToList() to return a List<T>
    }
