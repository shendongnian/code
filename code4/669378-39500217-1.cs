    public static XName ResolveName(this XObject xObj, XName name)
    {
        //If no namespace has been added, use default namespace anyway
        if (string.IsNullOrEmpty(name.NamespaceName))
        {
            name = xObj.Document.Root.GetDefaultNamespace() + name.LocalName;
        }
        return name;
    }
