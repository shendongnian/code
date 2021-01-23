    [MetadataTypeAttribute(typeof(PRODUCT.PRODUCTMetadata))]
    public partial class PRODUCT
    {
    	internal sealed class PRODUCTMetadata
    	{
    		// Metadata classes are not meant to be instantiated.
    		private PRODUCTMetadata()
    		{
    		}
    		
    		[StringLength(8)]
    		public string Product_code { get; set; }
    	}
    }
