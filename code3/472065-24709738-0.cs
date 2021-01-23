        static public IEnumerable<Type> GetTypesFromLibrary<T>(String library)
        {
            var MyAsemblies = AppDomain.CurrentDomain.GetAssemblies()
                             .Where(a=>a.GetName().Name.Equals(library))
                             .Select(a=>a);
            var Exported = MyAsemblies
                             .FirstOrDefault()
                             .GetExportedTypes();
            var Asignable = Exported
                             .Where (t=> !t.IsInterface && !t.IsAbstract
                             && typeof(T).IsAssignableFrom(t))
                             .Select(t=>t)
                             .AsEnumerable();
            return Asignable;
        }
        static public T GetInstanceOf<T>(String library, String FullClassName)
        {
            Type Type = GetTypesFromLibrary<T>(library)
                            .Where(t => t.FullName.Equals(FullClassName))
                            .FirstOrDefault();
            if (Type != null)
            {
                T Instance = (T)Activator.CreateInstance(Type);
                return Instance;
            }
            return default(T);
        }
