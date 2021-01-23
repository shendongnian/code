	var assembly = Assembly.Load("System.Web, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");
	var assemblyType = assembly.GetType("System.Web.MimeMapping");
	var getMimeMappingMethod = assemblyType.GetMethod("GetMimeMapping", BindingFlags.Static | BindingFlags.NonPublic) ??
							   assemblyType.GetMethod("GetMimeMapping", BindingFlags.Static | BindingFlags.Public);
	var mapping = (string)getMimeMappingMethod.Invoke(null, new object[] { fileName });
