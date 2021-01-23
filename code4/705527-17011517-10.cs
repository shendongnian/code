    var doc = PdfReader.Open(@"icpc_briefing_1_sep_10.pdf");
    Console.WriteLine("Number of pages: {0}", doc.PageCount);
    
    Console.WriteLine();
    Console.WriteLine("=== INFO ===");
    foreach (KeyValuePair<string, PdfItem> pair in doc.Info)
    {
        Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
    }
    
    byte[] xmlData = GetMetadata(doc);
    if (xmlData != null)
    {
        Console.WriteLine();
        Console.WriteLine("=== XMP ===");
        Console.Write(Encoding.UTF8.GetString(xmlData));
        Console.WriteLine();
    }
    byte[] GetMetadata(PdfDocument doc)
    {
        // PdfSharp does not have direct support for the XML metadata, but it does
        // allow you to go poking into the internal structure.
        PdfItem metadataItem;
        if (doc.Internals.Catalog.Elements.TryGetValue("/Metadata", out metadataItem))
        {
            var metadataRef = (PdfReference) metadataItem;
            var metadata = (PdfDictionary) metadataRef.Value;
            return metadata.Stream.Value;
        }
        return null;
    }
