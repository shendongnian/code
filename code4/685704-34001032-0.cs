        public static string FriendlyName(this Type type)
        {
            if (type.IsGenericType)
            {
                var namePrefix = type.Name.Split(new [] {'`'}, StringSplitOptions.RemoveEmptyEntries)[0];
                var genericParameters = type.GetGenericArguments().Select(FriendlyName).ToCsv();
                return namePrefix + "<" + genericParameters + ">";
            }
            return type.Name;
        }
