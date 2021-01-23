    public static string GetDisplayName(Enum enumValue)
    {
      return enumValue.GetType()?
     .GetMember(enumValue.ToString())?[0]?
     .GetCustomAttribute<DisplayAttribute>()?
     .Name;
    }
