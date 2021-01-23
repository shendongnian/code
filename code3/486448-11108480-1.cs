    public static class FileUtil
    {
    
        public static void CopyMultiple(string sourceFilePath, params string[] destinationPaths)
        {
            if (string.IsNullOrEmpty(sourceFilePath)) throw new ArgumentException("A source file must be specified.", "sourceFilePath");
        	
        	if (destinationPaths == null || destinationPaths.Length == 0) throw new ArgumentException("At least one destination file must be specified.", "destinationPaths");
        	
        	using (var source = File.OpenRead(sourceFilePath))
        	{
        		var buffer = new byte[4096];
        		int read;
        		
        		FileStream[] outputs = null;
        		
        		try 
        		{
        			outputs = (from path in destinationPaths
        						select new FileStream(path, FileMode.CreateNew)).ToArray();
        			
        			while((read = source.Read(buffer, 0, buffer.Length)) > 0)
        			{
        				foreach(var output in outputs) output.Write(buffer, 0, read);
        			}
        		}
        		finally
        		{
        			if (outputs != null)
        			{
        				foreach(var stream in outputs) stream.Dispose();
        			}
        		}
        	}
        }
    
    }
