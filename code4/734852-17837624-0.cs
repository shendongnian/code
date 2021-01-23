    [MetadataType(typeof(YourEntityMetaData))]
    public partial class YourEntity
    {
       
    }
    
    public class YourEntityMetaData
    {   
       [Required(ErrorMessage = "Board cannot be empty")]
       public int ProviderID   { get; set; }    
    }
