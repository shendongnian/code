    public static class EnumHelper
    {
        public static list_of_t = Enum.GetValues(typeof(t)).Cast<t>().ToList();
        // returns the string description of the enum.
        public static string GetEnumDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);
            if (attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
