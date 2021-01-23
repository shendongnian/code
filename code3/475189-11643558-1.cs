    static AssemblyLocator()
        {
            AllDlls = GetAllDlls();
            SubscribersInBin = GetSubscribersInBin();
        }
        public static IEnumerable<Type> TypesImplementingInterface(Assembly[] assemblies, Type desiredType)
        {
            return assemblies
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => IsAssignableToGenericType(type, desiredType));
        }
        public static bool IsAssignableToGenericType(Type givenType, Type genericType)
        {
            if (givenType == null) throw new ArgumentNullException("givenType");
            if (genericType == null) throw new ArgumentNullException("genericType");
            var interfaceTypes = givenType.GetInterfaces();
            foreach (var it in interfaceTypes)
            {
                if (it.IsGenericType)
                {
                    if (it.GetGenericArguments()[0].Name.Equals(genericType.GetGenericArguments()[0].Name))
                        return true;
                }
            }
            Type baseType = givenType.BaseType;
            if (baseType == null) return false;
            return (baseType.IsGenericType &&
                baseType.GetGenericTypeDefinition() == genericType) ||
                IsAssignableToGenericType(baseType, genericType);
        }
        private static ReadOnlyCollection<string> GetAllDlls()
        {
            string binFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            IList<string> dllFiles = Directory.GetFiles(binFolder, "*.dll", SearchOption.TopDirectoryOnly).ToList();
            return new ReadOnlyCollection<string>(dllFiles);
        }
        private static ReadOnlyCollection<Type> GetSubscribersInBin()
        {
            IList<Assembly> assembliesFoundInBin = new List<Assembly>();
            foreach (var item in AllDlls)
            {
                var assembly = System.Reflection.Assembly.LoadFrom(item);
                assembliesFoundInBin.Add(assembly);
            }
            var typesInBin = TypesImplementingInterface(assembliesFoundInBin.ToArray(), typeof(ISubscriber<T>));
            return new ReadOnlyCollection<Type>(typesInBin.ToList<Type>());
        }
