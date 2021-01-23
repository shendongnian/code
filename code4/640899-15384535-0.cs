    public List<Type> GetTypesFromAssembly()
            {
                List<Type> listOfAllTypes = new List<Type>();
                Assembly[] allAssembliesInCurrentDomain = AppDomain.CurrentDomain.GetAssemblies();
    
                foreach (Assembly assembly in allAssembliesInCurrentDomain)
                {
                    listOfAllTypes.AddRange(assembly.GetTypes());
                }
    
                return listOfAllTypes;        
            }
    public List<string> GetSystemNamespaces()
            {
                List<string> namespaces = new List<string>();            
    
                List<Type> types = GetTypesFromAssembly();
    
                foreach (Type type in types)
                {
                    if (type.Namespace != null)
                    {
                        namespaces.Add(type.Namespace.ToString());
                        namespaces = namespaces.Distinct().ToList();
                    }
                }
                return namespaces;
            }
