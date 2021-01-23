		public static T FetchValue<T>(string name)
		{
			T value;
			if (TryFetchValue(name, out value))
				return value;
			throw new HttpRequestValidationException("A " + name + " must be specified.");
		}
		public static T FetchValue<T>(string name, T default_value)
		{
			T value;
			if (TryFetchValue(name, out value))
				return value;
			return default_value;
		}
		private static bool TryFetchValue<T>(
			 string name,
			 out T value)
		{
			var page = HttpContext.Current.Handler as Page;
			string str = page.Request.QueryString[name];
			if (str == null)
			{
				value = default(T);
				return false;
			}
			value = (T)Convert.ChangeType(str, typeof(T));
			return true;
		}
