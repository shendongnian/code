    void Iterate(XmlNode parent) {
        //do something with
        //parent.Name
        //parent.Value
        //parent.Attributes
        foreach(XmlNode child in parent.ChildNodes) {
            Iterate(child);
        }
    }
    XmlDocument document = new XmlDocument();
    document.Load(filename);
    XmlNode parent = document.DocumentElement;
    Iterate(parent);
