    public static class EnumExtensions
    {
        public static String ToDescription<TEnum>(this TEnum e) where TEnum : struct
        {
            var type = typeof(TEnum);
            if (!type.IsEnum) throw new InvalidOperationException("type must be an enum");
            
            var memInfo = type.GetMember(e.ToString());
            if (memInfo != null & memInfo.Length > 0)
            {
                var descAttr = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (descAttr != null && descAttr.Length > 0)
                {
                    return ((DescriptionAttribute)descAttr[0]).Description;
                }
            }
            return e.ToString();
        }
        
        public static TEnum ToEnum<TEnum>(this String description) where TEnum : struct
        {
            var type = typeof(TEnum);
            if (!type.IsEnum) throw new InvalidOperationException("type must be an enum");
            
            foreach (var field in type.GetFields())
            {
                var descAttr = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (descAttr != null && descAttr.Length > 0)
                {
                    if (((DescriptionAttribute)descAttr[0]).Description == description)
                    {
                        return (TEnum)field.GetValue(null);
                    }
                }
                else if (field.Name == description)
                {
                    return (TEnum)field.GetValue(null);
                }
            }
            return default(TEnum); // or throw new Exception();
        }
    }
