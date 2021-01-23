    public class FooBarAttribute : Attribute, IMetadataAware
    {
        public FooBarAttribute(string bar)
        {
            Bar = bar;
        }
        public string Bar { get; private set; }
        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues["foo"] = Bar;
        }
    }
