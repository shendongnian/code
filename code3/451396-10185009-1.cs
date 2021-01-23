    public class EnumUtils
    {
      public static string stringValueOf(Enum value)
      {
        var fi = value.GetType().GetField(value.ToString());
        var attributes = (DescriptionAttribute[]) fi.GetCustomAttributes( typeof(DescriptionAttribute), false);
        if (attributes.Length > 0)
        {
            return attributes[0].Description;
        }
        else
        {
            return value.ToString();
        }
      }
    
      public static object enumValueOf(string value, Type enumType)
      {
        string[] names = Enum.GetNames(enumType);
        foreach (string name in names)
        {
          if (stringValueOf((Enum)Enum.Parse(enumType, name)).Equals(value))
          {
              return Enum.Parse(enumType, name);
          }
        }
    
        throw new ArgumentException("The string is not a description or value of the specified enum.");
      }
    }
