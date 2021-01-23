    using System.Reflection;
    XElement doc;
    using (var stream = Assembly.GetExecutingAssembly().
                        .GetManifestResourceStream("MyNameSpace.MyXML.xml"))
    {
        doc = XElement.Load(stream);
    }
