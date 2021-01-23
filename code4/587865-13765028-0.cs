    public static T Resolve<T>()
    {
       Type Implementation = typeSettings[typeof(T)]; // <--- use typeof here
       ConstructorInfo constructor = Implementation.GetConstructors()[0];
       ParameterInfo[] constructorParam = constructor.GetParameters();
       if (constructorParam.Length == 0)
          Activator.CreateInstance(Implementation);
       List<object> paramList = new List<object>(constructorParam.Length);
       foreach(ParameterInfo param in constructorParam)
          paramList.Add(Resolve(param.ParameterType));
       return (T)constructor.Invoke(paramList.ToArray()); // <--- cast to T here
    }
