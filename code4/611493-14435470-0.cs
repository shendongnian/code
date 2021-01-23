        /// <summary>
        /// Defines an EnumExtensions type.
        /// </summary>
        public static class EnumExtensions
        {
            /// <summary>
            /// Gets the value from a DescriptionAttribute applied to the enum.
            /// </summary>
            /// <param name="value">Enum value.</param>
            /// <returns>DescriptionAttribute value, or null if no attribute is applied.</returns>
            public static string Description(this Enum value)
            {
                var type = value.GetType();
                var fieldInfo = type.GetField(value.ToString(CultureInfo.InvariantCulture));
    
                var descriptionAttributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
    
                return descriptionAttributes.Length > 0
                           ? ((DescriptionAttribute)descriptionAttributes[0]).Description
                           : null;
            }
