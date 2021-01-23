    public class Class1
    {
    	StorageFolder _localFolder = null;
    
    	public Class1()
    	{
    		_localFolder = ApplicationData.Current.LocalFolder;
                    // call to setup removed here because constructors
                    // do not support async/ await keywords
    	}
    	public StorageFolder _LocalFolder
    	{
    		get
    		{
    			return _localFolder;
    		}
    
    	}
    
          // now public... (note Task return type)
    	async public Task SetUpStorageFolders()
    	{
    		try
    		{
    			_localFolder = await _localFolder.CreateFolderAsync("TestFolder", CreationCollisionOption.FailIfExists);
    
    		}
    		catch (Exception)
    		{
    			throw;
    		}
    	}
    }
