    Type[] classes = new Type[] { typeof(A), typeof(B) };           
    foreach (Type t in classes)
    {
        Type listType = typeof(List<>);
        Type[] typeArgs = {t};
        Type genericType = listType.MakeGenericType(typeArgs);
        IList list  = (IList)Activator.CreateInstance(genericType);
    }
