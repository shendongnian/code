    public class ExtensionManager : IExtensionManager
    {
    	private readonly IEnumerable<ExportFactory<IExtension, ExtensionMetadata>> _extensions;
    
    	public ExtensionManager(IEnumerable<ExportFactory<IExtension, ExtensionMetadata>> extensions)
    	{
    		_extensions = extensions;
    	}
    
    	public void DoWork(int accountID)
    	{
    		foreach (var extension in _extensions)
    		{
    			if (extension.Metadata.AccountID == accountID)
    			{
    				using (var foo = extension.CreateExport())
    				{
    					foo.Value.DoWork();
    				}
    			}
    		}
    	}
    }
