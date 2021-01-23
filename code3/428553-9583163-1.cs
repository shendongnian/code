    public static Int32 GetIntValue(Enum en)
        {
            Type type = en.GetType();
            return TemplateControlExtension.GetInt32(null, en);
        }
    public static string GetStringNameFromValue(Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] info = type.GetMember(en.ToString());
            if (info != null && info.Length > 0)
            {
                object[] attrs = info[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                {
                   return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return TemplateControlExtension.GetString(null, en);
        }
