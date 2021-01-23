    public class ServerCertificateServiceBehaviorExtensionElement : BehaviorExtensionElement
    {
        [ConfigurationProperty("applicationPolicy", IsRequired = true)]
        public string ApplicationPolicy
        {
            get
            {
                return (string)base["applicationPolicy"];
            }
            set
            {
                base["applicationPolicy"] = value;
            }
        }
        [ConfigurationProperty("subjectName", IsRequired = true)]
        public string SubjectName
        {
            get
            {
                return (string)base["subjectName"];
            }
            set
            {
                base["subjectName"] = value;
            }
        }
        [ConfigurationProperty("storeLocation", DefaultValue = 2)]
        public StoreLocation StoreLocation
        {
            get
            {
                return (StoreLocation)base["storeLocation"];
            }
            set
            {
                base["storeLocation"] = value;
            }
        }
        [ConfigurationProperty("storeName", DefaultValue = 5)]
        public StoreName StoreName
        {
            get
            {
                return (StoreName)base["storeName"];
            }
            set
            {
                base["storeName"] = value;
            }
        }
        public override Type BehaviorType
        {
            get { return typeof(ServerCertificateServiceBehavior); }
        }
        protected override object CreateBehavior()
        {
            return new ServerCertificateServiceBehavior(
                    this.StoreName, 
                    this.StoreLocation, 
                    this.SubjectName, 
                    this.ApplicationPolicy);
        }
    }
