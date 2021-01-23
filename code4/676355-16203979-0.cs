    using System;
    using System.Web.DynamicData;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Customer.CustomerMetaData))]
    public partial class Customer
    {
    
        class CustomerMetaData
        {
             // Apply RequiredAttribute
             [Required(ErrorMessage = "Title is required.")]
             public string Title;
        }
    
    }
    
    
