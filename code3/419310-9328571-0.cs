    [XmlIncludeAttribute(typeof(CustomNode))]
    [XmlIncludeAttribute(typeof(CustomNode2))]
    [XmlRoot("node")]
    class Node
    {
        [XmlElement("node")]
        public Node[] Children { get; set; }
    }
    [XmlRoot("custom-node")]
    class CustomNode : Node { }
    [XmlRoot("custom-node-2")]
    class CustomNode2 : Node { }
