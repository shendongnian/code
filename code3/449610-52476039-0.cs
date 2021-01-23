        public static void ResetAllStaticsVariables(Type type)
        {
            var fields = type.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.Public);
            foreach (var fieldInfo in fields)
            {
                fieldInfo.SetValue(null, GetDefault(type));
            }
        }
        public static object GetDefault(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }
