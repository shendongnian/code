    public static string Format(IFormatProvider provider, string format, params object[] args)
    {
        if ((format == null) || (args == null))
        {
            throw new ArgumentNullException((format == null) ? "format" : "args");
        }
    ...
    }
