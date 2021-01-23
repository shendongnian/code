    public enum EnumB
    {
        // make it equivalent to enum in ClassA
    }
    public static EnumB ToEnumB(this EnumA enumAValue) 
    {
        EnumB newValue = (EnumB)(int)enumAValue;
    }
