        namespace EFExtensions
        {
            /// <summary>
            /// Implement SQL Default Values from System.ComponentModel.DefaultValueAttribute
            /// </summary>
            public class DefaultValueConvention : Convention
            {
                /// <summary>
                /// Annotation Key to use for Default Values specified directly as an object
                /// </summary>
                public const string DirectValueAnnotationKey = "DefaultValue";
                /// <summary>
                /// Annotation Key to use for Default Values specified as SQL Strings
                /// </summary>
                public const string SqlValueAnnotationKey = "DefaultSql";
                /// <summary>
                /// Implement SQL Default Values from System.ComponentModel.DefaultValueAttribute
                /// </summary>
                public DefaultValueConvention()
                {
                    // Implement SO Default Value Attributes first
                    this.Properties()
                            .Where(x => x.HasAttribute<EFExtensions.DefaultValueAttribute>())
                            .Configure(c => c.HasColumnAnnotation(
                                c.GetAttribute<EFExtensions.DefaultValueAttribute>().GetDefaultValueAttributeKey(),
                                c.GetAttribute<EFExtensions.DefaultValueAttribute>().GetDefaultValueAttributeValue()
                                ));
                    // Implement Component Model Default Value Attributes, but only if it is not the SO implementation
                    this.Properties()
                            .Where(x => x.HasAttribute<System.ComponentModel.DefaultValueAttribute>())
                            .Where(x => !x.HasAttribute<MiniTuber.DataAnnotations.DefaultValueAttribute>())
                            .Configure(c => c.HasColumnAnnotation(
                                DefaultValueConvention.DirectValueAnnotationKey, 
                                c.GetAttribute<System.ComponentModel.DefaultValueAttribute>().Value
                                ));
                }
            }
            /// <summary>
            /// Extension Methods to simplify the logic for building column annotations for Default Value processing
            /// </summary>
            public static partial class PropertyInfoAttributeExtensions
            {
                /// <summary>
                /// Wrapper to simplify the lookup for a specific attribute on a property info.
                /// </summary>
                /// <typeparam name="T">Type of attribute to lookup</typeparam>
                /// <param name="self">PropertyInfo to inspect</param>
                /// <returns>True if an attribute of the requested type exists</returns>
                public static bool HasAttribute<T>(this PropertyInfo self) where T : Attribute
                {
                    return self.GetCustomAttributes(false).OfType<T>().Any();
                }
                /// <summary>
                /// Wrapper to return the first attribute of the specified type
                /// </summary>
                /// <typeparam name="T">Type of attribute to return</typeparam>
                /// <param name="self">PropertyInfo to inspect</param>
                /// <returns>First attribuite that matches the requested type</returns>
                public static T GetAttribute<T>(this System.Data.Entity.ModelConfiguration.Configuration.ConventionPrimitivePropertyConfiguration self) where T : Attribute
                {
                    return self.ClrPropertyInfo.GetCustomAttributes(false).OfType<T>().First();
                }
                /// <summary>
                /// Helper to select the correct DefaultValue annotation key based on the attribute values
                /// </summary>
                /// <param name="self"></param>
                /// <returns></returns>
                public static string GetDefaultValueAttributeKey(this EFExtensions.DefaultValueAttribute self)
                {
                    return String.IsNullOrWhiteSpace(self.DefaultSql) ? DefaultValueConvention.DirectValueAnnotationKey : DefaultValueConvention.SqlValueAnnotationKey;
                }
                /// <summary>
                /// Helper to select the correct attribute property to send as a DefaultValue annotation value
                /// </summary>
                /// <param name="self"></param>
                /// <returns></returns>
                public static object GetDefaultValueAttributeValue(this EFExtensions.DefaultValueAttribute self)
                {
                    return String.IsNullOrWhiteSpace(self.DefaultSql) ? self.Value : self.DefaultSql;
                }
            }
        }
