    var assembly = typeof(PegHelper).GetTypeInfo().Assembly;
    using (var stream = assembly.GetManifestResourceStream("Parsers.Peg.SelfDef.xml"))
    using (var reader = new StreamReader(stream))
    {
        string xmlText = reader.ReadToEnd();
        return XDocument.Parse(xmlText);
    }
