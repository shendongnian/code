    T ReturnObject<T>(T x)
    {
    Type typeDynamic=x.GetType();
    Type[] argTypes = new Type[] { };
    ConstructorInfo cInfo = typeDynamic.GetConstructor(argTypes);
    T instacneOfClass = (T)cInfo.Invoke(null);
    return instacneOfClass;
    }
