    private Sharelist RecurseHierarchy(XElement sharelistNode, Sharelist parent)
    {
        // your traversing code goes here
        // get your data and create a new Sharelist object
        // if it has a childen node, traverse it and call this same method on the child
        // Sharelist nodes
        Sharelist childShareList = new Sharelist();
        // ...
        parent.Children.Add(childShareList);
        var children = sharelistNode.Element("Children");
        
        if (children != null)
        {
            var items = children.Elements("ShareListItem");
            foreach(var listItem in items)
            {
                RecurseHierarchy(listItem, childShareList);
            }
        }
        // Just in case we want to chain some method
        return parent;
    }
