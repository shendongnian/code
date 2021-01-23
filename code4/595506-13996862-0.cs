    public class MetadataSourceWrapper : MarshalByRefObject
    {
        public MetadataSource MetadataSource { get; private set; }
        public MetadataSourceWrapper()
        {
            MetadataSource = new MetadataSource();
        }
        public void Load(string path)
        {
            MetadataSource.Load(path);
        }
    }
