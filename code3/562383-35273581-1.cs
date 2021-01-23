    static class EnumExtensions
    {
        /// returns the localized Name, if a [Display(Name="Localised Name")] attribute is applied to the enum member
        /// returns null if there isnt an attribute
        public static string DisplayNameOrEnumName(this Enum value)
        // => value.DisplayNameOrDefault() ?? value.ToString()
        {
            // More efficient form of ^ based on http://stackoverflow.com/a/17034624/11635
            var enumType = value.GetType();
            var enumMemberName = Enum.GetName(enumType, value);
            return enumType
                .GetEnumMemberAttribute<DisplayAttribute>(enumMemberName)
                ?.GetName() // Potentially localized
                ?? enumMemberName; // Or fall back to the enum name
        }
        /// returns the localized Name, if a [Display] attribute is applied to the enum member
        /// returns null if there is no attribute
        public static string DisplayNameOrDefault(this Enum value) =>
            value.GetEnumMemberAttribute<DisplayAttribute>()?.GetName();
        static TAttribute GetEnumMemberAttribute<TAttribute>(this Enum value) where TAttribute : Attribute =>
            value.GetType().GetEnumMemberAttribute<TAttribute>(value.ToString());
        static TAttribute GetEnumMemberAttribute<TAttribute>(this Type enumType, string enumMemberName) where TAttribute : Attribute =>
            enumType.GetMember(enumMemberName).Single().GetCustomAttribute<TAttribute>();
    }
