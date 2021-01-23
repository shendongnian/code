    public ObservableCollection<T> GetAll<T>()
    {
        var typeName = typeof(T).FullName;
        var indexOfDot = typeName.LastIndexOf('.');
        var newTypeName = typeName.SubString(0, indexOfDot) + '.' + typeName.SubString(indexOfDot + 1);
        var newType = Type.GetType(newTypeName);
        var methodTypes = new [] { typeof(T), newType };
        var method = GetType().GetMethod("GetAll");
        var typedMethod = method.MakeGenericMethod(methodTypes);
        return (ObservableCollection<T>) typedMethod.Invoke(this, new object[0]);
    }
