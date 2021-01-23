    public static BaseErrWarn GetAttribute(Enum enumVal)
    {
        return (BaseErrWarn)Attribute.GetCustomAttribute(ForValue(enumVal), typeof(BaseErrWarn));
    }
    private static MemberInfo ForValue(Enum errorEnum)
    {
        return typeof(BaseErrWarn).GetField(Enum.GetName(typeof(BaseErrWarn), errorEnum));
    }
    
