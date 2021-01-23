    public static class EnumToFrendlyString
    {
        public static string ToFrendlyString<T>(this T value)
            where T : struct
        {
            return value.GetEnumDescription();
        }
        public static string GetEnumDescription<T>(this T value)
            where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("Only use with enums", "value");
            }
            var descriptionAttribute = typeof(T)
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .Cast<DescriptionAttribute>()
                .FirstOrDefault()
            return (descriptionAttribute != null)
                ? descriptionAttribute.Description
                : value.ToString();
        }
    }
