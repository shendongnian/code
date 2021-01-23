    public IEnumerable GetGenericListFor(object myObject){
        var listType = typeof(List<>);
        listType.MakeGenericType(myObject.GetType())
        return Activator.CreateInstance(listType);
    }
