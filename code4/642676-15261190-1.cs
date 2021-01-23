    /// <summary>
    /// Returns the path root if absolute, or the topmost folder if relative.
    /// The original path is returned if no containers exist.
    /// </summary>
    public static string GetTopmostFolder(string path)
    {
    	Uri inputPath;
    
    	if (Uri.TryCreate(path, UriKind.Absolute, out inputPath))
    		return Path.GetPathRoot(path);
    
    	if (Uri.TryCreate(path, UriKind.Relative, out inputPath))
    		return path.Split(Path.DirectorySeparatorChar).First();
    	
    	return path;
    }
