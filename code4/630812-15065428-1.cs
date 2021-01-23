    public static XAttribute GetAttributeNamespaceSafe(this XElement parent, 
            XName attrName, XNamespace documentDefaultNamespace)
    {
        if (attrName.Namespace == documentDefaultNamespace)
            attrName = attrName.LocalName;
        return parent.Attribute(attrName);
    }
