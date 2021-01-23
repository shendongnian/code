        /// <summary>
        /// Creates a new object that contains the properties of the two objects merged together.
        /// </summary>
        /// <typeparam name="T">The class type to merge.</typeparam>
        /// <param name="pDefaults">Instance of the defaults object.</param>
        /// <param name="pSettings">Instance of the settings object.</param>
        /// <returns>A new instance of T with the merged results.</returns>
        public static T ObjectMerge<T>(T pDefaults, T pSettings, bool pMergeFields = true, bool pMergeProperties = true) where T : class, new()
        {
            T target = new T();
            Type type = typeof(T);
            List<MemberInfo> infos = new List<MemberInfo>(type.GetMembers());
            foreach (MemberInfo info in infos)
            {
                // Copy values from either defaults or settings
                if (pMergeFields && info.MemberType == MemberTypes.Field)
                {
                    FieldInfo field = (FieldInfo)info;
                    if (field.IsPublic)
                    {
                        object value = field.GetValue(pSettings);
                        value = (value == null) ? field.GetValue(pDefaults) : value;
                        field.SetValue(target, value);
                    }
                }
                // Copy values from either defaults or settings
                if (pMergeProperties && info.MemberType == MemberTypes.Property)
                {
                    PropertyInfo prop = (PropertyInfo)info;
                    if (prop.CanWrite && prop.CanRead)
                    {
                        object value = prop.GetValue(pSettings, null);
                        value = (value == null) ? prop.GetValue(pDefaults, null) : value;
                        prop.SetValue(target, value, null);
                    }
                }
            }
            return target;
        }
