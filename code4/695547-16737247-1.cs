    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    
    //make sure the namespace is equal to the other partial class ItemRequest
    namespace MvcApplication1.Models 
    {
        [MetadataType(typeof(ItemRequestMetaData))]
        public partial class ItemRequest
        {
        }
    
        public class ItemRequestMetaData
        {
            [Required]
            public int RequestId {get;set;}
    
            //...
        }
    }
