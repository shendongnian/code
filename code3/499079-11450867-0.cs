    // The very first thing to do is create the Package in a using statement.
    // This makes sure it's saved and closed when you're done.
    using (Package package = Package.Open(...))
    {
        // XML reading, substituting etc. goes here.
        // Eventually...
        //create a new part
        PackagePart pkgprtData = package.CreatePart(uriData, "application/xml");
        // Don't need the test data anymore.
        // Assuming you need UnicodeEncoding, set it up like this.
        var writerSettings = new XmlWriterSettings
        {
            Encoding = Encoding.Unicode,
        };
        // Shouldn't need a MemoryStream at all; write straight to the part stream.
        // Note using statements to ensure streams are flushed and closed.
        using (Stream toStream = pkgprtData.GetStream())
        using (XmlWriter writer = XmlWriter.Create(toStream, writerSettings))
            templateXml.Save(writer);
        // No other copying should be necessary.
        // In particular, your toStream.CopyTo(stream) appeared
        // to be appending the part's data to the package's stream
        // (the physical file), which is a bug.
    } // This closes the using statement for the package, which saves the file.
