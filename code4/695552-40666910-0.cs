    using System.ComponentModel.DataAnnotations;
    
    namespace MvcApplication1.Models 
    {
        [MetadataType(typeof(ItemRequest.MetaData))]
        public partial class ItemRequest
        {
		    internal class MetaData
		    {
                [Required]
                public int RequestId {get;set;}
    
                //...
            }
        }
    }
