    static object NullableSafeChangeType(string input, Type type)
    {
        Type underlyingType = Nullable.GetUnderlyingType(type);
        if (underlyingType == null) // Non-nullable; convert directly
        {
            return Convert.ChangeType(input, type);
        }
        else
        {
            return input == null || input == "" ? null
                : Convert.ChangeType(input, underlyingType);
        }
    }
