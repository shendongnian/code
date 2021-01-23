    private static readonly RuntimeTypeModel serializer;
    static MyType() { // your type-initializer for class MyType
        serializer = TypeModel.Create();
        serializer.UseImplicitZeroDefaults = false;
    }
    ... then when needed:
    serializer.Serialize(stream, obj);
    ...
    ObjType obj = (ObjType)serializer.Deserialize(stream, null, typeof(ObjType));
    
