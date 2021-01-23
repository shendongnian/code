    [EdmFunction("SqlServer", "STR")]
    public static string StringConvert(decimal? number, int? length)
    {
        throw EntityUtil.NotSupported(Strings.ELinq_EdmFunctionDirectCall);
    }
