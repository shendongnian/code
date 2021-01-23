    public bool HasOrInheritsTypeWithDataContractAttribute(Type t)
    {
        do {
            if (t.GetCustomAttributes(typeof(DataContractAttribute), true).Length > 0) {
                return true;
            }
            t = t.BaseType;
        } while (t != null);
        return false;
    }
