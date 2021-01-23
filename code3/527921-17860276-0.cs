    public class KnownTypesBinder : System.Runtime.Serialization.SerializationBinder {
        public KnownTypesBinder() {
            KnownTypes = new List<Type>();
            AliasedTypes = new Dictionary<string, Type>();
        }
        public IList<Type> KnownTypes { get; set; }
        public IDictionary<string, Type> AliasedTypes { get; set; }
        public override Type BindToType(string assemblyName, string typeName) {
            if (AliasedTypes.ContainsKey(typeName)) { return AliasedTypes[typeName]; }
            var type = KnownTypes.SingleOrDefault(t => t.Name == typeName);
            if (type == null) {
                type = Type.GetType(Assembly.CreateQualifiedName(assemblyName, typeName));
                if (type == null) {
                    throw new InvalidCastException("Unknown type encountered while deserializing JSON.  This can happen if class names have changed but the database or the JavaScript references the old class name.");
                }
            }
            return type;
        }
        public override void BindToName(Type serializedType, out string assemblyName, out string typeName) {
            assemblyName = null;
            typeName = serializedType.Name;
        }
    }
