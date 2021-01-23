    class TypeNameConverter : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            typeName = typeName.Replace("MyOldNamespace", "MyNewNamespace");
            assemblyName = assemblyName.Replace("MyOldNamespace", "MyNewNamespace");
            return Type.GetType(string.Format("{0}, {1}", typeName, assemblyName));
        }
    }
