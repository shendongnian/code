    public static string DefinitionTitle(this Type type)
        {
            if (type.IsGenericType)
            {
                var namePrefix = type.Name.Split(new[] { '`' }, StringSplitOptions.RemoveEmptyEntries)[0];
                var genericParameters = type.GetGenericArguments().Select(a => a.Name).ToCsv();
                return namePrefix + "<" + genericParameters + ">";
            }
            return type.Name;
        }
