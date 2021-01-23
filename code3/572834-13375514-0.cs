        public List<Type> GetEnumerableOfType<T>(params object[] constructorArgs) where T : class
        {
            List<Type> objects = new List<Type>();
            IEnumerable<Type> s = typeof(T).GetTypeInfo().Assembly.ExportedTypes.Where(myType => myType.GetTypeInfo().IsClass &&
                                                             !myType.GetTypeInfo().IsAbstract &&
                                                             myType.GetTypeInfo().IsSubclassOf(typeof(T)));
            foreach (Type type in s)
                objects.Add(type);
            return objects;
        }
