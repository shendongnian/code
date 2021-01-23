    public static List<string> GetValuesOf<TEnum>()
        where TEnum : struct // can't constrain to enums so closest thing
    {
        return Enum.GetValues(typeof(TEnum)).Cast<Enum>()
                   .Select(val => val.GetAttribute<ValueOfEnumAttribute>().Value)
                   .ToList();
    }
