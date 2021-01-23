     public static string Resource(this string name)
	 {
	     return new ResourceManager(
                 "YourApp.Namespace.Resources",
                 Assembly.GetExecutingAssembly()
                    .GetString(name) ?? name;
	 }
