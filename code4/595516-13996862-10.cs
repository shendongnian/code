    public class MetadataLoader : MarshalByRefObject, IMetadataLoader
    {
        public MetadataLoader() { }
        public void Init(MetadataSourceWrapper source)
        {
            ...
        }
        public Metadata Metadata { get; set; }
    }
