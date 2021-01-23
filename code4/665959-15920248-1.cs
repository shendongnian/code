        /// <summary>
        /// Given an enum value, if a <see cref="DescriptionAttribute"/> attribute has been defined on it, then return that.
        /// Otherwise return the enum name.
        /// </summary>
        /// <typeparam name="T">Enum type to look in</typeparam>
        /// <param name="value">Enum value</param>
        /// <returns>Description or name</returns>
        /// <remarks>
        /// Tip: To localise the description text, use a description attribute that takes its value from a resource, e.g.
        /// <c>Microsoft.Practices.EnterpriseLibrary.Configuration.Design.SRDescriptionAttribute</c>.
        /// </remarks>
        public static string ToDescription<T>(this T value) where T : struct {
            if(!typeof(T).IsEnum) {
                throw new ArgumentException(Properties.Resources.TypeIsNotAnEnum, "T");
            }
            var fieldName = Enum.GetName(typeof(T), value);
            if(fieldName == null) {
                return string.Empty;
            }
            var fieldInfo = typeof(T).GetField(fieldName, BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Static);
            if(fieldInfo == null) {
                return string.Empty;
            }
            var descriptionAttribute = (DescriptionAttribute) fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();
            if(descriptionAttribute == null) {
                return fieldInfo.Name;
            }
            return descriptionAttribute.Description;
        }
