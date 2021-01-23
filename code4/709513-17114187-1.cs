    void Main()
    {
        object valueObj = new List<object> { 1, 2, 3 };
        Type type = typeof(int[]);
    
        Type elementType = type.GetElementType();
        MethodInfo castMethod = typeof(Enumerable).GetMethod("Cast")
            .MakeGenericMethod( new System.Type[]{ elementType } );
        MethodInfo toArrayMethod = typeof(Enumerable).GetMethod("ToArray")
            .MakeGenericMethod( new System.Type[]{ elementType } );
        
        var castedObjectEnum = castMethod.Invoke(null, new object[] { valueObj });
        var castedObject = toArrayMethod.Invoke(null, new object[] { castedObjectEnum });
        castedObject.Dump();
    }
