    public enum EnumB
    {
        // make it equivalent to EnumA
    }
    public static EnumB ToEnumB(this EnumA enumAValue) 
    {
        EnumB newValue = (EnumB)(int)enumAValue;
    }
