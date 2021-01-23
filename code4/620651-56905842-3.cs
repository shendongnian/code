    // Return this parent node
    private string GetPath(ValidationEventArgs args)
    {
        var tagProblem =((XmlElement)((XmlSchemaValidationException)args.Exception).SourceObject);
        return iterateParentNode(tagProblem.ParentNode) + "/" +tagProblem.Name;
    }
    
    private string iterateParentNode(XmlNode args)
    {
        var node = args.ParentNode;
        if (args.ParentNode.NodeType == XmlNodeType.Element)
        {
            return interateParentNode(node) + @"/" + args.Name;
        }
        return "";
    }
