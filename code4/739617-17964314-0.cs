    [MetadataType(typeof(ContentMetadata))]
    public partial class Content
    {
    
    }
    
    public class ContentMetadata
    {
        [AllowHtml]
        public string ContentHtml { get; set; }
    }
