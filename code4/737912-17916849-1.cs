    var ns = "test";
    var file = Path.Combine(folderPath, "File.test");
    var doc = XDocument.Load(file);
    // Or var characters = document.Root.Element(ns + "Characters")
    var characters = document.Descendants(ns + "Characters").FirstOrDefault();
    if (characters != null)
    {
        characters.Add(new XElement(ns + "Character");
        doc.Save(file);
    }
