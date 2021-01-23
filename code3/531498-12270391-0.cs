    public static int GetValueOf(string enumName, string enumConst)
    {
        Type enumType = Type.GetType(enumName);
        if (enumType == null)
        {
            throw new ArgumentException("Specified enum type could not be found", "enumName");
        }
        object value = Enum.Parse(enumType, enumConst);
        return Convert.ToInt32(value);
    }
