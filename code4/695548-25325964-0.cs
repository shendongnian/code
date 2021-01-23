    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    namespace YourApplication.Models
    {
    	public interface IEntityMetadata
    	{
    		[Required]
            Int32 Id { get; set; }
    	}
    	
    	[MetadataType(typeof(IEntityMetadata))]
        public partial class Entity : IEntityMetadata
        {
            /* Id property has already existed in the mapped class */
        }
    }
