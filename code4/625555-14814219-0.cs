    public DImage(byte[] filebytes) : this()	// Remove if no parameterless constructor
    {
    	MemoryStream filestream = null;
    	BinaryReader binReader = null;
    	if (filebytes != null && filebytes.Length > 0)
    	{
    		using (filestream = new MemoryStream(filebytes))
    		{
    			this.ProcessStream(filestream);
    		}
    	}
    	else
    		throw new Exception(@"Couldn't read file from disk.");
    }
    
    public DImage(Stream stream) : this()	// Remove if no parameterless constructor
    {
    	this.ProcessStream(stream);
    }    
    
    public DImage(string strFileName) : this()	// Remove if no parameterless constructor
    {
    	// make sure the file exists
    	if (System.IO.File.Exists(strFileName) == true)
    	{
    		this.strFileName = strFileName;
    		
    		// process stream from file
    		this.ProcessStream(System.IO.File.Open(strFileName));
    	}
    	else
    	   throw new Exception(@"Couldn't find file '" + strFileName);
    }
    
    ...
    
    private ProcessStream(Stream myStream)
    {
    	if (filestream != null && filestream.Length > 0 && filestream.CanSeek == true)
    	{
    		//do stuff
    	}
    	else
    		throw new Exception(@"Couldn't read file from disk.");
    }
