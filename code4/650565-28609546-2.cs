    public Type GetTheType(string strFullyQualifiedName)
    {
        Type type = Type.GetType(strFullyQualifiedName);
        if (type != null)
            return type;
        foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
        {
            type = asm.GetType(strFullyQualifiedName);
            if (type != null)
               return type;
        }
        return null;
    }
