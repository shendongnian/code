    void Main()
    {
        object o = new List<int> { 1, 2, 3 };
        var a = ListToArray(o);
        a.Dump();
    }
    
    public static object ListToArray(object list)
    {
        if (list == null)
            throw new ArgumentNullException("list");
        
        var listType = list.GetType();
        if (!listType.IsGenericType || listType.GetGenericTypeDefinition() != typeof(List<>))
            throw new ArgumentException("list", "list is not a List<T>");
            
        var toArrayMethod = listType.GetMethod("ToArray");
        return toArrayMethod.Invoke(list, null);
    }
