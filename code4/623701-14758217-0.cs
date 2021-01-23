    public static TEnum GetEnumValue<TEnum>(string str)
        where TEnum : struct //enum is not valid here, unfortunately
    {
        foreach (MemberInfo memInfo in typeof(TEnum).GetMembers())
        {
            object[] attrs = memInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attrs != null && attrs.Length > 0)
            {
                if (((DescriptionAttribute)attrs[0]).Description == str)
                {
                    return (TEnum)(object)Enum.Parse(typeof(TEnum),memInfo.Name);
                }
            }
        }
        // Unable to find a description attribute for the enum.
        return (TEnum)(object)Enum.Parse(typeof(TEnum),str);
    }
