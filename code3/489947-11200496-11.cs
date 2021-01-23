    public static string GetValue(VoteType enumValue)
    {
        FieldInfo fiendInfo = typeof(VoteType).GetField(enumValue.ToString());
        if (!ReferenceEquals(fiendInfo, null))
        {
            object[] attributes = fieldInfo.GetCustomAttributes(typeof(EnumValueAttribute), true);
            if (!ReferenceEquals(attributes, null) && attributes.Length > 0)
            {
                return ((EnumValueAttribute)attributes[0]).Value;
            }
        }
        //Not valid value or it didn't have the attribute
        return null;
    }
