    var doc = new XDocument(new XElement("Test"));
    var doc2 = new XDocument(doc);
    doc.Root.Name = "Test2";
    string name = doc.Root.Name.ToString();
    string name2 = doc2.Root.Name.ToString();
