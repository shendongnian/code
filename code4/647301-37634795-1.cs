    using System.ComponentModel;
    using System.Reflection;
    public static DescriptionAttribute GetDescription(this Enum value)
    {
        FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
        if (fieldInfo == null) return null;
        return (DescriptionAttribute)fieldInfo.GetCustomAttribute(typeof(DescriptionAttribute));
    }
