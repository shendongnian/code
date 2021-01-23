    public static bool IsPathVirtualized(string path)
    {
    		bool isVirtualized = false;
    		string pathToVirtualizedUserFolder = Path.Combine
    		(
    			Environment.SpecialFolder.LocalApplicationData + 
    			@"Microsoft\Windows\Temporary Internet Files\Virtualized\"
    		);
     		if(path.StartsWith(pathToVirtualizedUserFolder))
    		{
    			isVirtualized = true;
    		}
    		return isVirtualized;
    }
