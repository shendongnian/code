    public static T GetDataInterface<T>() where T : class
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        
        T theObject = (from t in assembly.GetTypes()
                       where t.GetInterfaces().Contains(typeof(T))
                         && t.GetConstructor(Type.EmptyTypes) != null
                         && t.Namespace == _namespace
                       select Activator.CreateInstance(t) as T).FirstOrDefault() as T;
        return theObject as T;
    }
