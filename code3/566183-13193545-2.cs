    private Type ClassType { get; set; }
    var mi = GetType().GetMethod("CreateObject");
    var miConstructed = mi.MakeGenericMethod(ClassType);
    var instance = miConstructed.Invoke(this, null);
    model = (instance)ser.Deserialize(sr);
    
    private T CreateObject<T>()
    {
        return (T)Activator.CreateInstance(typeof(T));
    }
