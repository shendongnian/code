    static void Main(string[] args)
    {
        var xml = @"<FolderTree>
            <Folder>
                <Name>One</Name>
                <OutlineLevel>0</OutlineLevel>
            </Folder>
            <Folder>
                <Name>Two</Name>
                <OutlineLevel>1</OutlineLevel>
            </Folder>
            <Folder>
                <Name>Three</Name>
                <OutlineLevel>2</OutlineLevel>
            </Folder>
            <Folder>
                <Name>Four</Name>
                <OutlineLevel>3</OutlineLevel>
            </Folder>
            <Folder>
                <Name>Five</Name>
                <OutlineLevel>2</OutlineLevel>
            </Folder>
            <Folder>
                <Name>Six</Name>
                <OutlineLevel>3</OutlineLevel>
            </Folder>
            <Folder>
                <Name>Seven</Name>
                <OutlineLevel>3</OutlineLevel>
            </Folder>
            <Folder>
                <Name>Eight</Name>
                <OutlineLevel>1</OutlineLevel>
            </Folder>
            </FolderTree>
        ";
        var root = XElement.Parse(xml);
        var elements = root.Elements().ToList();
        var rootFolderString = GetItemsAtLevel(new Queue<XElement>(elements), 0).First().ToString();
    }
    private static void TransformElement(XElement folder)
    {
        folder.Element("OutlineLevel").Remove();
        var nameElement = folder.Element("Name");
        nameElement.Remove();
        folder.Add(new XAttribute(nameElement.Name, nameElement.Value));
    }
    private static IEnumerable<XElement> GetItemsAtLevel(Queue<XElement> elements, int level)
    {
        while (elements.Any())
        {
            var parent = elements.Dequeue();
            var children = new Queue<XElement>();
            while (elements.Any() && (int)elements.Peek().Element("OutlineLevel") > level)
            {
                children.Enqueue(elements.Dequeue());
            }
            if (children.Any())
            {
                var subtree = GetItemsAtLevel(children, level + 1);
                parent.Add(subtree);
            }
            TransformElement(parent);
            yield return parent;
        }
    }
