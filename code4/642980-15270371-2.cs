    public static T? GetTextOrNullStruct<T>(this TextBox txt, GlobalSist.Common.Utils.ParserCondition? parserCondition, bool throwOnValidation)
        where T : struct, IComparable<T>
    {
        return GlobalSist.Common.Utils.Parsers.ConvertStruct<T>(
            GetTextOrNull(txt), parserCondition, throwOnValidation);
    }
    public static T? ConvertStruct<T>(IConvertible value, ParserCondition? parserCondition, bool throwOnValidation)
        where T : struct, IComparable<T>
    {
        try
        {
            if ((value == null) ||
                (value is string && string.IsNullOrEmpty((string)value)))
            {
                if (throwOnValidation)
                    throw new ArgumentNullException("value");
                else
                    return null;
            }
            return Parsers.Convert<T>(value, parserCondition, true);
        }
        catch (ArgumentOutOfRangeException)
        {
            if (throwOnValidation)
                throw;
            else
                return null;
        }
    }
