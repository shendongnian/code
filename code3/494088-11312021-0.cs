    public IList<object> GetBoxedEnumValues<TEnum>()
    {
        Type enumType = typeOf(TEnum);
        if (!enumType.IsEnum)
        {
            throw new NotSupportedException(
                string.Format("\"{0}\" is not an Enum", enumType.Name));
        }
        return Enum.GetValues(enumType).Cast<object>().ToList();      
    }
