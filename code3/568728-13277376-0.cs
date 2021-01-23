	public static string[] Split(string str, string separator)
	{
		string[] result;
	#if DOTNET
		result = str.Split(new string[] { separator }, System.StringSplitOptions.None);
	#else
		result = str.Split(separator);
	#endif
		return result;
	}
