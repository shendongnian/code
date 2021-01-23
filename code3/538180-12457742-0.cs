    public class EngineerAttribute : Attribute, IMetadataAware
    {
        public EngineerAttribute(bool isFoo)
        {
            IsFoo = isFoo;
        }
        public bool IsFoo { get; private set; }
        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues["IsFoo"] = IsFoo;
        }
    }
