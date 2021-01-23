      [XmlRoot(ElementName = "node")]
      public class Node
      {
      [XmlArrayItem(typeof(CustomNode), ElementName = "custom-node")]
      [XmlArrayItem(typeof(CustomNode2), ElementName = "custom-node-2")]  
        public List<Node> Children { get; set; }     
      }
      [XmlRoot(ElementName = "custom-node")]
      public class CustomNode : Node { }
      [XmlRoot(ElementName = "custom-node-2")]
      public class CustomNode2 : Node { }
