    // NOTE: Change the "EFTestDBModel" namespace to the name of your model
    [System.Data.Objects.DataClasses.EdmFunction("EFTestDBModel", "ConvertToInt32")]
    public static int ConvertToInt32(string myStr)
    {
        throw new NotSupportedException("Direct calls are not supported.");
    }
    // NOTE: Change the "EFTestDBModel" namespace to the name of your model
    [System.Data.Objects.DataClasses.EdmFunction("EFTestDBModel", "ConvertToDecimal")]
    public static decimal ConvertToDecimal(string myStr)
    {
        throw new NotSupportedException("Direct calls are not supported.");
    }
