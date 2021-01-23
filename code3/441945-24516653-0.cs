    [MetadataAttribute]
    public class DbManagerMetadataAttribute : Attribute, IDbManagerMetadata
    {
        public DataProvider DataProvider { get; set; }
    }
