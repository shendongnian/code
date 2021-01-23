        public class NodeManager
    	{
    		public List<Node> Nodes { get; set; }
    	}
    
    	public class Node
    	{
    		public string Name { get; set; }
    		public List<NodeType> NodeTypes{ get; set; }
    		public int Length { get; set; }
    		public int XCoordinate { get; set; }
    		public int YCoordinate { get; set; }
    	}
    
    	public class NodeType
    	{
    		public string Name { get; set; }
    		public string SomeOtherNodeTypeProperty { get; set; }
    		public string YetAnotherNodeTypeProperty { get; set; }
    	}
	
