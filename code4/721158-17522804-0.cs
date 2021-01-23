    [MetadataAttribute, AttributeUsage (AttributeTargets.Class, AllowMultiple = true)]
    public class ExportMetaFooAttribute : Attribute, IFooMeta
    {
        public string Name { get; private set; }
        public string Version { get; private set; }
     
        public ExportFooAttribute (string name, string version)
        {
            Name = name;
            Version = version;
        }
    }
