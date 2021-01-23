	void Main()
	{
		var ub = new UriBuilder("http://example.com/somefolder");
		ub.AddPath("file.txt");	
                var fullUri = ub.Uri;
	}
	public static class MyExtensions
	{
		public static UriBuilder AddPath(this UriBuilder builder, string pathValue)
		{
		var path = builder.Path;
		
		if (path.EndsWith("/") == false)
		{
			path = path + "/";
		}
		
		path += Uri.EscapeDataString(pathValue);
		
		builder.Path = path;
		}
	}
