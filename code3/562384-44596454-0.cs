    /// <summary>
    /// Get human-readable version of enum
    /// </summary>
    /// <returns>DisplayAttribute.Name field of given enum</returns>
    public static string GetDisplayName<T>(this T enumValue) where T : IComparable, IFormattable, IConvertible
    {
        if (!typeof(T).IsEnum)
            throw new ArgumentException("Argument must be of type Enum");
        try
        {
            return enumValue.GetType() // GetType causes exception if DisplayAttribute.Name is not set
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }
        catch // If there's no DisplayAttribute.Name set, just return the ToString value
        {
            return enumValue.ToString();
        }
    }
