        public static string GetDescription(this Enum enumValue)
        {
            Type type = enumValue.GetType();
            FieldInfo info = type.GetField(enumValue.ToString());
            DescriptionAttribute[] da = (DescriptionAttribute[])(info.GetCustomAttributes(typeof(DescriptionAttribute), false));
            if (da.Length > 0)
                return da[0].Description;
            else
                return string.Empty; 
        }
