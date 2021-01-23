	private static T FetchValue<T>(string name, Nullable<T> default_value = null) where T : struct
	{
		var page = HttpContext.Current.Handler as Page;
		
		string str = page.Request.QueryString[name];
		
		if (str == null)
		{
			if (default_value == null)
			{
				throw new Exception("A " + name + " must be specified.");
			}
			else
			{
				return (T)Convert.ChangeType(default_value, typeof(T));
			}
		}
		
		return default(T);
	}
