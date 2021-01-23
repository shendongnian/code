    public static string GetDisplayName(this Enum enumValue)
    {
        return enumValue.GetType().GetMember(enumValue.ToString())
                       .First()
                       .GetCustomAttribute<DisplayAttribute>()
                       .Name;
    }
