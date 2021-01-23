    public IEnumerable<object> OfType(this List<object> list, string typeName)
    {
        Type type = Type.GetType(typeName);
        return list.Where(x => x != null && type.IsAssignableFrom(x.GetType()));
    }
