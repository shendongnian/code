    public static class PathExtensions
    	{
    		public static string GetFullPath(this string filePath)
    		{
    			if (Platform.IsAndroid) // platform is a class that I have to tell me which platfrom I am at :)
    			{
    				return Constants.AndroidResourcePath + filePath;
    			}
    			if (Platform.IsIOS)
    			{
    				return Path.Combine(Constants.iOSRootPath, filePath);
    			}
    			return Path.Combine(Constants.RootPath, filePath);
    		}
    	}
