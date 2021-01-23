    public void HandleLevel(XElement levelRoot)
    {
        var children = levelRoot.Element("Children");
        if(children == null)
            return;
        var items = children.Elements("ShareListItem");
        foreach(var item in item)
        {
            // Perform action here
            // File.Copy or so.
            // Handle child's children:
            HandleLevel(item);
        }
    }
