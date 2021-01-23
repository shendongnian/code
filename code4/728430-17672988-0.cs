    [SecuritySafeCritical]
    public object CreateInstanceAndUnwrap(string assemblyName, string typeName)
    {
        ObjectHandle handle = this.CreateInstance(assemblyName, typeName);
        if (handle == null)
        {
            return null;
        }
        return handle.Unwrap();
    }
