    [MetadataAttribute]
    public class ExtensionMetadataAttribute : ExportAttribute, IExtensionMetadata
    {
    	public int AccountID { get; set; }
    
    	public ExtensionMetadataAttribute(int accountID) : base(typeof (IExtension))
    	{
    		AccountID = accountID;
    	}
    }
