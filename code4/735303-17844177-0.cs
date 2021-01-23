    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(CustomerMetadata))]
    public partial class Customer
    {
        public class CustomerMetadata
        {
            [Required]
            public string Name { get; set; }
    
            // other properties...
        }
    }
