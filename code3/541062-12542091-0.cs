    public static class EnumExtensions
    {
        public static SelectList ToSelectList<TEnum>(this TEnum enumObj)
        {
            var enumType = typeof(TEnum);
            if (enumType.IsGenericType && enumType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                enumType = enumType.GetGenericArguments()[0];
            }
            var fields = enumType.GetFields(
                BindingFlags.Static | BindingFlags.GetField | BindingFlags.Public
            );
            var values = Enum.GetValues(enumType).OfType<TEnum>();
            var items =
                from value in values
                from field in fields
                let xmlEnumAttribute = field
                    .GetCustomAttributes(
                        typeof(XmlEnumAttribute), true
                    )
                    .OfType<XmlEnumAttribute>()
                    .FirstOrDefault()
                let name = (xmlEnumAttribute != null)
                    ? xmlEnumAttribute.Name
                    : value.ToString()
                where value.ToString() == field.Name
                select new { Id = value, Name = name };
            return new SelectList(items, "Id", "Name", enumObj);
        }
    }
