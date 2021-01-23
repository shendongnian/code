    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class DisplayForUserTypeAttribute : Attribute, IMetadataAware
    {
        private readonly UserType _userType;
        public DisplayForUserType(UserType userType)
        {
            _userType = userType;
        }
        public override object TypeId
        {
            get
            {
                return this;
            }
        }
        public string Name { get; set; }
        public void OnMetadataCreated(ModelMetadata metadata)
        {
            if (CurrentContext.UserType != _userType)
                return;
            metadata.DisplayName = Name;
        }
    }
