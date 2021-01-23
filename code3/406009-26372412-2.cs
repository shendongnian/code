    // Version 1.0
    [Flags]      
    public enum MyEnum
    {
        None = 0,
        First = 1,
        Second = 2,
        All = First | Second
    }
    public MyEnum MyEnumProperty = MyEnum.All;
