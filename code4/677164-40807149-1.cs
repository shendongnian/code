        private static Type[] KnownTypes { get; set; }
        public static Type[] ResolveKnownTypes()
        {
            if (MyGlobalObject.KnownTypes == null)
            {
                List<Type> t = new List<Type>();
                List<AssemblyName> c = System.Reflection.Assembly.GetEntryAssembly().GetReferencedAssemblies().Where(b => b.Name == "DeveloperCode" | b.Name == "Library").ToList();
                foreach (AssemblyName n in c)
                {
                    System.Reflection.Assembly a = System.Reflection.Assembly.Load(n);
                    t.AddRange(a.GetTypes().ToList());
                }
                MyGlobalObject.KnownTypes = t.ToArray();
            }
            return IOChannel.KnownTypes;
        }
