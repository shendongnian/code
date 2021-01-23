    public static bool IsZeroSizeStruct(Type t)
    {
        return t.IsValueType && Marshal.SizeOf(t) == 1 && 
            t.GetFields((BindingFlags)0x34).All(fi => IsZeroSizeStruct(fi.FieldType));
    }
