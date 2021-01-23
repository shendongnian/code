    public static bool IsZeroSizeStruct(Type t)
    {
        return t.IsValueType && !t.IsPrimitive && 
               t.GetFields((BindingFlags)0x34).All(fi => IsZeroSizeStruct(fi.FieldType));
    }
