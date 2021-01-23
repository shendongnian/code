    int ResolveDynamic(IBase a)
    {
        MethodInfo method = typeof(IContainer).GetMethod("Resolve");
        var handlerType = typeof(IHandler<>).MakeGenericType(a.GetType());
        var enumerableType = typeof(IEnumerable<>).MakeGenericType(handlerType);
        MethodInfo generic = method.MakeGenericMethod(enumerableType);
        
        var result = (IEnumerable<object>)generic.Invoke(_container, null);
        return result.Count();
    }
