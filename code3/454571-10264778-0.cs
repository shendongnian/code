    private List<string> GetTypes()
    {
        List<string> typeNames = new List<string>();
        /// or AppDomain.CurrentDomain.GetAssemblies() or loop through the folder with assemblies
        Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
        foreach (AssemblyName an in assembly.GetReferencedAssemblies() )
        {
            foreach (Type type in an.GetTypes())
            {
                typeNames.add(type.Name);
            }  
        }
        return typeNames;
    }
