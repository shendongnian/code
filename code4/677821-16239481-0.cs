    public static class FileRepository
    {
    	public static FileInfo GetFile(string fileName)
    	{
    		if(!File.Exists(fileName))
    		{
    			FileInfo Download;
    			
    			// Use some unique name + filename as Mutex Name
    			using(new Mutex(true, fileName))
    			{
    				// Will block if another Process already downloads the file
    				if(Mutex.WaitOne())
    				{
    					// Download the File
    					// ...
    				}
    			}
    			
    			return Download;
    		}
    	}
    }
