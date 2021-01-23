        public static T GetCustomAttribute<T>(this PropertyInfo propertyInfo, bool inherit) where T : Attribute
        {
            object[] attributes = propertyInfo.GetCustomAttributes(typeof(T), inherit);
            return attributes == null || attributes.Length == 0 ? null : attributes[0] as T;
        }
        public static List<Type> GetImplementedInterfaces(Type type)
        {
            Type[] types = type.GetInterfaces();
            List<Type> lTypes = new List<Type>();
            foreach(Type t in types)
            {
                lTypes.Add(t);
            }
            return lTypes;
        }
