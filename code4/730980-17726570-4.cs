    private IEnumerable<EntityObject> GetFilteredData(Type entityType, SortedList<string, string> filterList, List<int> weeks)
    {
        var instance = (EntityObject)Activator.CreateInstance(entityType);
        return GetFilteredDataImpl((dynamic)instance, filterList, weeks);
    }
    private IEnumerable<T> GetFilteredDataImpl<T>(T entityType, SortedList<string, string> filterList, List<int> weeks) where T : EntityObject
    {
        var data = _modelContext.CreateObjectSet<T>().AsExpandable();
          // do more filtering and then call .ToList() to return a List<T>
    }
