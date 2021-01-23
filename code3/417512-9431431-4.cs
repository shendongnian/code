    public static class SelectListItemsForHelper
    {
        public static IEnumerable<SelectListItem> SelectListItemsFor<T>(T selected) where T : struct
        {
            Type t = typeof(T);
            if (t.IsEnum)
            {
                return Enum.GetValues(t).Cast<Enum>().Select(e => new SelectListItem { Value = e.ToString(), Text = e.GetDescription() });
            }
            return null;
        }
        public static string GetDescription<TEnum>(this TEnum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            if (fi != null)
            {
                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Length > 0)
                    return attributes[0].Description;
            }
            return value.ToString();
        }
    }
