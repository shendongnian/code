    [SecuritySafeCritical]
    public ObjectHandle CreateInstance(string assemblyName, string typeName)
    {
        if (this == null)
        {
            throw new NullReferenceException();
        }
        if (assemblyName == null)
        {
            throw new ArgumentNullException("assemblyName");
        }
        return Activator.CreateInstance(assemblyName, typeName);
    }
