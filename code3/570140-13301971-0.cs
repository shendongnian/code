    [Flags]
    public enum FilterFlagEnum
    {
        None = 0,
        Condition1 = 1,
        Condition2 = 2,
        Condition3 = 4,
        Condition4 = 8, 
        Condition5 = 16,
        Condition6 = 32,
        Condition7 = 64 
    }; 
    
    
    public void foo(FilterFlagEnum filterFlags = 0)
    {
            if ((filterFlags & FilterFlagEnum.Condition1) == FilterFlagEnum.Condition1)
            {
                //do this
            }
            if ((filterFlags & FilterFlagEnum.Condition2) == FilterFlagEnum.Condition2)
            {
                //do this
            }
    }
    foo(FilterFlagEnum.Condition1 | FilterFlagEnum.Condition2);
