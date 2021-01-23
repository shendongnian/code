    public static class Factory
    {
        public static object GetImporter(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
    
            var type = assembly.GetTypes().Single(t => t.Name.Equals(name));
            var importType = typeof (Importer<>).MakeGenericType(type);
    
            return Activator.CreateInstance(importType);
    
        }
    
        public static object GetProcessor(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetTypes()
                   .Single(t => t.Name.Equals(string.Format("{0}Processor", name)));
    
            return Activator.CreateInstance(type);
        }
    }
