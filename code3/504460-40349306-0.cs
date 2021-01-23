	public class Node
	{
		public int NodeID { get; set; }
		public string Name { get; set; }
		public virtual Node ParentNode { get; set; }
		public int? ParentNodeID { get; set; }
		public virtual ICollection<Node> ChildNodes { get; set; }
		public int? LeafID { get; set; }
		public virtual Leaf Leaf { get; set; }
	}
	public class Leaf
	{
		public int LeafID { get; set; }
		public string Name { get; set; }
		public virtual ICollection<Node> Nodes { get; set; }
	}
