    /// <summary>
    /// Tells a single Property to not be persisted to table.
    /// </summary>
    public class NoEntity : Attribute { }
        /// <summary>
    /// Extension to ignore attributes
    /// </summary>
    public static class FluentIgnore
    {
        /// <summary>
        /// Ignore a single property.
        /// Property marked with this attributes will no be persisted to table.
        /// </summary>
        /// <param name="p">IPropertyIgnorer</param>
        /// <param name="propertyType">The type to ignore.</param>
        /// <returns>The property to ignore.</returns>
        public static IPropertyIgnorer SkipProperty(this IPropertyIgnorer p, Type propertyType)
        {
            return p.IgnoreProperties(x => x.MemberInfo.GetCustomAttributes(propertyType, false).Length > 0);
        }
    }
