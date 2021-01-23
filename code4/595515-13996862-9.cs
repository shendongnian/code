    public interface IMetadataLoader
    {
        void Init(MetadataSourceWrapper source);
        Metadata Metadata { get; set; }
    }
