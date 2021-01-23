    public static string GetDescription<T>(this T en) where T : struct, IConvertible
    {
        Type type = en.GetType();
        if (!type.IsEnum)
        {
            throw new ArgumentException("The type is not an enum");
        }
        MemberInfo[] memInfo = type.GetMember(en.ToString());
        if (memInfo != null && memInfo.Length > 0)
        {
            object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attrs != null && attrs.Length > 0)
            {
                return ((DescriptionAttribute)attrs[0]).Description;
            }
        }
        return en.ToString();
    }
