    InitializeData2_NonGeneric(objects, properties, new List<Dictionary<string, object>>());
    //...
    static void InitializeData2_NonGeneric(IList objects, PropertyInfo[] props, List<Dictionary<string, object>> tod) {
        Type elementType = objects[0].GetType();
        var genericMethodInfo = typeof(Program).GetMethod("InitializeData2", BindingFlags.Static | BindingFlags.NonPublic);
        var genericMethod = genericMethodInfo.MakeGenericMethod(new Type[] { elementType });
    
        var genericGetterType = typeof(Func<,>).MakeGenericType(elementType,typeof(object));
        var genericCacheType = typeof(Dictionary<,>).MakeGenericType(typeof(string), genericGetterType);
        var genericCacheConstructor = genericCacheType.GetConstructor(new Type[] { });
        genericMethod.Invoke(null, new object[] { objects, props, tod, genericCacheConstructor.Invoke(new object[] { }) });
    }
