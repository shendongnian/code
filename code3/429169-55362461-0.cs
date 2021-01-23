    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    public static class EnumExtensions
    {
        /// <summary>
        /// Converts the bare enum value to a string using the <see cref="DescriptionAttribute"/>
        /// that was appplied to it.
        /// </summary>
        /// <typeparam name="TEn"></typeparam>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static string ToDescription<TEn>(this TEn enumValue) where TEn : struct
        {
            FieldInfo fi = enumValue.GetType().GetField(enumValue.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : enumValue.ToString();
        }
        /// <summary>
        /// Does the reverse lookup. If there is an enum member with the string <paramref name="enumString"/>
        /// as <see cref="DescriptionAttribute"/> it will be returned, otherwise the fallback value in
        /// <paramref name="fallback"/> will be returned.
        /// </summary>
        /// <typeparam name="TEn">Type of the enum in question.</typeparam>
        /// <param name="enumString">String serialization of Description annotated enum.</param>
        /// <param name="fallback">Default value to return.</param>
        /// <returns>Either the found value or the fallback.</returns>
        public static TEn FromDescription<TEn>(this string enumString, TEn fallback = default(TEn)) where TEn : struct
        {
            if (enumString != null)
            {
                FieldInfo[] fieldInfo = typeof(TEn).GetFields();
                foreach (var fi in fieldInfo)
                {
                    DescriptionAttribute[] attributes =
                        (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (attributes.Any(att => att.Description == enumString))
                    {
                        object rawConstantValue = fi.GetRawConstantValue();
                        return (TEn)rawConstantValue;
                    }
                }
            }
            return fallback;
        }
    }
