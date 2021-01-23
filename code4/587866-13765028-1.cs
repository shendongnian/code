    public static object Resolve(Type contract)
    {
       Type Implementation = typeSettings[contract];
        
       ConstructorInfo constructor = Implementation.GetConstructors()[0];
        
       ParameterInfo[] constructorParam = constructor.GetParameters();
        
       if (constructorParam.Length == 0)
          Activator.CreateInstance(Implementation);
        
       List<object> paramList = new List<object>(constructorParam.Length);
        
       foreach(ParameterInfo param in constructorParam)
          paramList.Add(Resolve(param.ParameterType));
        
       return constructor.Invoke(paramList.ToArray());
    }
    public static T Resolve<T>()
    {
       return (T)Resolve(typeof(T));
    }
