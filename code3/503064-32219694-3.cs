     public static string GetStringDescription(Enum en)
        {   
            var enumValueName = Enum.GetName(en.GetType(),en);
            FieldInfo fi = en.GetType().GetField(enumValueName);
            var attr = (StringDescriptionAttribute)fi.GetCustomAttribute(typeof(StringDescriptionAttribute));
            return attr != null ? attr.Name : "";
        }
