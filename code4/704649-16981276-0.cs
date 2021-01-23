        private static Type GetTypeOfList(PropertyInfo changedMember)
        {
            var listType = from i in changedMember.PropertyType.GetInterfaces()
                           where i.IsGenericType
                           let generic = i.GetGenericTypeDefinition()
                           where generic == typeof (IEnumerable<>)
                           select i.GetGenericArguments().Single();
            return listType.SingleOrDefault();
        }
