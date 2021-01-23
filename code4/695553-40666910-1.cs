    using System.ComponentModel.DataAnnotations;
    
    namespace MvcApplication1.Models 
    {
        [MetadataType(typeof(MetaData))]
        public partial class ItemRequest
        {
		    public class MetaData
		    {
                [Required]
                public int RequestId;
    
                //...
            }
        }
    }
