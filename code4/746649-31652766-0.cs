    public static class EnumHelper
    {
        public static SelectList GetSelectList<T>(string selectedValue, bool useNumeric = false)
        {
            Type enumType = GetBaseType(typeof(T));
            if (enumType.IsEnum)
            {
                var list = new List<SelectListItem>();
                // Add empty option
                list.Add(new SelectListItem { Value = string.Empty, Text = string.Empty });
                foreach (Enum e in Enum.GetValues(enumType))
                {
                    list.Add(new SelectListItem { Value = useNumeric ? Convert.ToInt32(e).ToString() : e.ToString(), Text = e.Description() });
                }
                return new SelectList(list, "Value", "Text", selectedValue);
            }
            return null;
        }
        private static bool IsTypeNullable(Type type)
        {
            return (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>));
        }
        private static Type GetBaseType(Type type)
        {
            return IsTypeNullable(type) ? type.GetGenericArguments()[0] : type;
        } 
