    public static Assembly GetAssembly(Type type)
    {
        if (type == null)
            throw new ArgumentNullException("type");
        Contract.EndContractBlock();
    
        Module m = type.Module;
        if (m == null)
            return null;
        else
            return m.Assembly;
    }
