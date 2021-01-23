    public static class Factory
    {
        public static object GetImporter(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
    
            var type = assembly.GetTypes().Single(t => t.Name.Equals(name));
            var genericListType = typeof (Importer<>).MakeGenericType(type);
    
            return Activator.CreateInstance(genericListType);
    
        }
    
        public static object GetProcessor(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetTypes()
                     .Single(t => t.Name.Equals(string.Format("{0}Processor", name)));
    
            return Activator.CreateInstance(type);
        }
    }
