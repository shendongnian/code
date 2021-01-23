    string ret = ResourceUtility.GetTempFileFromEmbeddedResource(Assembly.GetExecutingAssembly(),
        "outlook.addin.a.html", "a.html");
    var bsjs = ResourceUtility.GetTempFileFromEmbeddedResource(Assembly.GetExecutingAssembly(),
        "outlook.addin.bootstrap.js.bootstrap.min.js", "bootstrap.min.js");
     
    public static string GetTempFileFromEmbeddedResource(Assembly assembly, string resourceName, string fileName)
    {
        string output;
        using (Stream s = ResourceUtility.GetEmbeddedResourceStream(assembly, resourceName))
        {
            StreamReader sr = new StreamReader(s);
            output = sr.ReadToEnd();
        }
            
        return CreateLocalTempFile(output, fileName);
    }
