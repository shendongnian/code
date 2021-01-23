    public static XAttribute AddAttributeNamespaceSafe(this XElement parent, 
             XName attrName, string attrValue, XNamespace documentDefaultNamespace)
    {
        if (newAttrName.Namespace == documentDefaultNamespace)
            attrName = attrName.LocalName;
        var newAttr = new XAttribute(attrName, attrValue);
        parent.Add(newAttr);
        return newAttr;
    }
