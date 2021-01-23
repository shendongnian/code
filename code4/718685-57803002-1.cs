    public static string GetDisplayDescription(this Enum enumValue)
    {
        return enumValue.GetType().GetMember(enumValue.ToString())
            .FirstOrDefault()?
            .GetCustomAttribute<DisplayAttribute>()
            .GetDescription() ?? "unknown";
    }
