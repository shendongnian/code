    public class InheritanceSerializationBinder : DefaultSerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            switch (typeName)
            {
                case "parent[]": return typeof(Class1[]);
                case "parent": return typeof(Class1);
                case "child[]": return typeof(Class2[]);
                case "child": return typeof(Class2);
                default: return base.BindToType(assemblyName, typeName);
            }
        }
    }
