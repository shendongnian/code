    public static class FileRepository
    {
    	public static FileInfo GetFile(string fileName)
    	{
    		FileInfo MyFile;
    			
    		if(!File.Exists(fileName))
    		{
    			// Use some unique name + filename as Mutex Name
    			using(new Mutex(true, fileName))
    			{
    				// Will block if another Process already downloads the file
    				if(Mutex.WaitOne())
    				{
    					// Download the File and safe FileInfo in MyFile
    					// ...
    				}
    			}
    		}
    		else
    		{
    			MyFile = new FileInfo(fileName);
    		}		
    			
    		return MyFile;
    	}
    }
