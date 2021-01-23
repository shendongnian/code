    public class MustBeAValidInteger : ValidationAttribute, IMetadataAware
    {
        public override bool IsValid(object value)
        {
            return true;
        }
        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.AdditionalValues["errorMessage"] = ErrorMessage;
        }
    }
