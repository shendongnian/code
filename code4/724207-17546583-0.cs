    void SomeFunction<T>()
    {
        var type = typeof(T);
        if(type.IsArray)
        {
            var elementType = type.GetElementType();
            var method = typeof(Foo).GetMethod("SomeOtherFunction")
                                    .MakeGenericMethod(elementType);
            // invoke method
        }
        else
            foo.SomeOtherFunction<T>(...);
    }
