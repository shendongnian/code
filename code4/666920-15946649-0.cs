    var doc = new XmlDocument();
    doc.Load(FileName);
    XmlWriterSettings settings = new XmlWriterSettings { Encoding = Encoding.UTF8, Indent = true };
    new System.Threading.Timer((_) =>
        {
            using (var writer = XmlWriter.Create(destinationFile, settings))
            {
                doc.Save(writer);
            }
        })
    .Change(15000, -1);
