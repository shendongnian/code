    [XmlElement("nodes")]
    public NodeCollection Nodes { get; set; }
    [XmlElement("to_add")]
    public NodeCollection NodesToAdd { get; set; }
    [XmlElement("to_remove")]
    public NodeCollection NodesToRemove { get; set; }
    [XmlElement("available")]
    public NodeCollection NodesAvailable { get; set; }
