    [AttributeUsage(AttributeTargets.Field)]
    public class EnumDisplayNameAttribute : DisplayNameAttribute
    {
        public EnumDisplayNameAttribute()
            : base(string.Empty)
        {
        }
        public EnumDisplayNameAttribute(string displayName)
            : base(displayName)
        {
        }
    }
    public static class EnumExtensions
    {
        public static string ToDisplayName(this Enum enumValue)
        {
            var builder = new StringBuilder();
            var fields = GetEnumFields(enumValue);
            if (fields[0] != null)
                for (int i = 0; i < fields.Length; i++)
                {
                    var value = fields[i]
                        .GetCustomAttributes(typeof(EnumDisplayNameAttribute), false)
                        .OfType<EnumDisplayNameAttribute>()
                        .FirstOrDefault();
                    builder.Append(value != null
                                       ? value.DisplayName
                                       : enumValue.ToString());
                    if (i != fields.Length - 1)
                        builder.Append(", ");
                }
            return builder.ToString();
        }
        private static FieldInfo[] GetEnumFields(Enum enumValue)
        {
            var type = enumValue.GetType();
            return enumValue
                .ToString()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(type.GetField)
                .ToArray();
        }
    }
