    protected virtual bool IsValueTypeImpl()
    {
          return this.IsSubclassOf((Type) RuntimeType.ValueType);
    }
    public bool IsClass
    {
      [__DynamicallyInvokable] get
      {
        if ((this.GetAttributeFlagsImpl() & TypeAttributes.ClassSemanticsMask) == TypeAttributes.NotPublic)
          return !this.IsValueType;
        else
          return false;
      }
    }
