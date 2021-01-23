	public static class Extension
	{	
		public static T CreateCopy<T>(this T src)
			where T: new()
		{
				return (new Cloner<T>()).Clone(src);
		}	
	}	
