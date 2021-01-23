    public class CustomerDetails
    {
        public AccountDefinition AccountDefinition {get; set;}
        public SDOrganization SDOrganization {get; set;}
        public ICollection<AaaPostalAddress> AaaPostalAddresses { get; set; }
    }
