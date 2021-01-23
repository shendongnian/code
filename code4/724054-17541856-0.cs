    public static Stream GetResourceStream(string pathName, string resName, Assembly srcAssembly = null)
    {
    	if (srcAssembly == null) srcAssembly = Assembly.GetCallingAssembly();
    	var allNames = srcAssembly.GetManifestResourceNames();
    	return srcAssembly.GetManifestResourceStream(pathName + "." + resName);
    }
    public static string GetResourceString(string pathName, string resName, Assembly srcAssembly = null)
    {
    	if (srcAssembly == null) srcAssembly = Assembly.GetCallingAssembly();
    	StreamReader sr = new StreamReader(GetResourceStream(pathName, resName, srcAssembly));
    	string s = sr.ReadToEnd();
    	sr.Close();
    	return s;
    }
