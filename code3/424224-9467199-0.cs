    public bool FindOverride(MethodInfo baseMethod, Type type)
    {
        if(baseMethod==null)
          throw new ArgumentNullException("baseMethod");
        if(type==null)
          throw new ArgumentNullException("type");
        if(!type.IsSubclassOf(baseMethod.ReflectedType))
            throw new ArgumentException(string.Format("Type must be subtype of {0}",baseMethod.DeclaringType));
        while(true)
        {
            var methods=type.GetMethods(BindingFlags.Instance|
                                        BindingFlags.DeclaredOnly|
                                        BindingFlags.Public|
                                        BindingFlags.NonPublic);
            var method=methods.FirstOrDefault(m=>m.GetBaseDefinition()==baseMethod))
            if(method!=null)
              return method;
            type=type.BaseType;
        }
    }
