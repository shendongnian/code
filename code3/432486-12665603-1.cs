    /// <summary>
    /// Gets the XmlDeclaration if it exists, creates a new if not.
    /// </summary>
    /// <param name="xmlDocument"></param>
    /// <returns></returns>
    public static XmlDeclaration GetOrCreateXmlDeclaration(this XmlDocument xmlDocument)
    {
        XmlDeclaration xmlDeclaration = null;
        if (xmlDocument.HasChildNodes)
            xmlDeclaration = xmlDocument.FirstChild as XmlDeclaration;
    
        if (xmlDeclaration != null)
            return xmlDeclaration;
        //Create an XML declaration. 
        xmlDeclaration = xmlDocument.CreateXmlDeclaration("1.0", null, null);
    
        //Add the new node to the document.
        XmlElement root = xmlDocument.DocumentElement;
        xmlDocument.InsertBefore(xmlDeclaration, root);
        return xmlDeclaration;
    }
