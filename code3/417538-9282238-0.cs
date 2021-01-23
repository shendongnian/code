    private static void Main(string[] args)
    {
        var myXslTrans = new XslCompiledTransform();
        var doc = new XmlDocument();
        doc.LoadXml(GetResourceTextFile("ProjectName.MainTransform.xslt"));
        myXslTrans.Load(doc);
        var sb = new StringBuilder();
        var sw = new StringWriter(sb);
        var xsltArgs = new XsltArgumentList();
        xsltArgs.AddParam("Name", "", "test name");
        xsltArgs.AddParam("filedName", "", "test filed name");
        var docXml = new XmlDocument();
        docXml.LoadXml(GetResourceTextFile("ProjectName.Test.xml"));
        myXslTrans.Transform(docXml, xsltArgs, sw);
        var test = sw.ToString();
    }
    public static string GetResourceTextFile(string filename)
    {
        string result = string.Empty;
        var assembly = Assembly.GetExecutingAssembly();
        using (Stream stream = assembly.GetManifestResourceStream(filename))
        {
            if (stream != null)
            {
                using (var sr = new StreamReader(stream))
                {
                    result = sr.ReadToEnd();
                }
            }
        }
        return result;
    }
