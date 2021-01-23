        /// <summary>
    /// Provides extensions to System.Linq object. 
    /// </summary>
    public static class LinqExtensions
    {
        #region Methods
        /// <summary>
        /// Returns the underlying core type for a given type.
        /// </summary>
        /// <param name="typ">Type to evaluate.</param>
        /// <returns>Type.</returns>
        private static Type GetCoreType(Type typ)
        {
            if (typ != null && IsNullable(typ))
            {
                if (!typ.IsValueType)
                {
                    return typ;
                }
                else
                {
                    return Nullable.GetUnderlyingType(typ);
                }
            }
            else
            {
                return typ;
            }
        }
        /// <summary>
        /// Determines whether the type provided is nullable.
        /// </summary>
        /// <param name="typ">Type to evaluate.</param>
        /// <returns>True if is nullable else false.</returns>
        private static bool IsNullable(Type typ)
        {
            return !typ.IsValueType || (typ.IsGenericType && typ.GetGenericTypeDefinition() == typeof(Nullable<>));
        }
        /// <summary>
        /// Converts a generic list of type T into a data table.
        /// </summary>
        /// <typeparam name="T">The type the list consists of.</typeparam>
        /// <param name="items">Generic list being extended.</param>
        /// <returns>DataTable representing the strongly typed list.</returns>
        public static DataTable ToDataTable<T>(this Collection<T> items)
        {
            if (!object.Equals(items, null))
            {
                using (DataTable data = new DataTable(typeof(T).Name))
                {
                    data.Locale = System.Globalization.CultureInfo.CurrentCulture;
                    PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    foreach (PropertyInfo prop in properties)
                    {
                        data.Columns.Add(prop.Name, GetCoreType(prop.PropertyType));
                    }
                    foreach (T item in items)
                    {
                        object[] values = new object[properties.Length];
                        for (int i = 0; i < properties.Length; i++)
                        {
                            values[i] = properties[i].GetValue(item, null);
                        }
                        data.Rows.Add(values);
                    }
                    return data;
                }
            }
            return null;
        }
        #endregion
    }
