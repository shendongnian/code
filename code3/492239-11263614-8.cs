    if (File.Exists(sourceFile)) {
        System.IO.File.Copy(sourceFile, targetPath, true);
    } else {
        XDocument doc = new XDocument(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XComment("This is a test"),
            new XElement("root")
        );
        doc.Save(targetPath);
    }
