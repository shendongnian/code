    public static object InitializeTarget(Type type)
        {
            object target = CreateObject(type);
            foreach (PropertyInfo propertyInfo in type.GetProperties())
            {
                if (propertyInfo.PropertyType.IsClass && propertyInfo.CanWrite
                    && propertyInfo.PropertyType != typeof(string)
                    && (propertyInfo.IsDefined(typeof(DataMemberAttribute), true)))
                    propertyInfo.SetValue(target, InitializeTarget(propertyInfo.PropertyType), null);
            }
            return target;
        }
        public static object CreateObject(Type type)
        {
            if (typeof(IList).IsAssignableFrom(type) && type.IsGenericType)
            {
                Type[] genericArguments = type.GetGenericArguments();
                if (genericArguments.Length == 1)
                {
                    var list = (IList)Activator.CreateInstance(type);
                    //Adding default value
                    list.Add(CreateObject(genericArguments[0]));
                    return list;
                }
            }
            //If the object is only to serialize, you can use it
            return FormatterServices.GetUninitializedObject(type);
            //or
            //            return Activator.CreateInstance(type);
        }
