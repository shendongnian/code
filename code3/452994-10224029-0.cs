    // Returns the file-system path for a given path.
    public static string GetMappedPath(string path)
    {
    	if (HostingEnvironment.IsHosted)
    	{
    		if (!Path.IsPathRooted(path))
    		{
    			// We are about to call MapPath, so need to ensure that 
    			// we do not pass an absolute path.
    			// 
    			// We use HostingEnvironment.MapPath, rather than 
    			// Server.MapPath, to allow this method to be used
    			// in application startup. Server.MapPath calls 
    			// HostingEnvironment.MapPath internally.
    			return HostingEnvironment.MapPath(path);
    		}
    		else {
    			return path;
    		}
    	}
    	else 
    	{
    		throw new ApplicationException (
                    "I'm not in an ASP.NET hosted environment :-(");
    	}
    }
