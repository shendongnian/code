    public class SimpleDtoSpawner : DtoSpawner{
        private readonly Dictionary<string, Type> types;
    
        public SimpleDtoSpawner() {
            Assembly assembly = Assembly.GetAssembly(typeof (GenericDTO));
            string baseNamespace = typeof (GenericDTO).Namespace ; 
            types = assembly.GetTypes()
                            .Where(t => t.Namespace.StartsWith(baseNamespace))
                            .ToDictionary(t => t.Name);
        }
        public GenericDTO New(string type) {
            return (GenericDTO) Activator.CreateInstance(types[name]).Unwrap();
        }
    }
