    static class EnumExtensions
    {
        /// returns the localized Name, if a [Display(Name="x")] attribute is applied to the enum member
        /// returns null if there isnt an attribute
        public static string DisplayNameOrEnumName(this Enum value)
        {
            var enumElementName = value.ToString();
            return value.GetType()
                .GetEnumMemberAttribute<DisplayAttribute>(enumElementName)
                ?.GetName() // Potentially localized
                ?? enumElementName; // Or fall back to the enum name
        }
        /// returns the localized Name, if a [Display] attribute is applied to the enum member
        /// returns null if there is no attribute
        public static string DisplayNameOrDefault(this Enum value) =>
            value.GetType().GetEnumMemberAttribute<DisplayAttribute>(value.ToString())
                ?.GetName();
        static TAttribute GetEnumMemberAttribute<TAttribute>(this Enum enumValue) 
                where TAttribute : Attribute =>
            enumValue.GetType().GetEnumMemberAttribute<>(enumValue.ToString());
        static TAttribute GetEnumMemberAttribute<TAttribute>(this Type enumType, 
                string enumMemberName) where TAttribute : Attribute =>
            enumType.GetMember(enumMemberName).Single().GetCustomAttribute<TAttribute>();
    }
