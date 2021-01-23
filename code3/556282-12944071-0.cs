	void Main()
	{
		var rootNode = new Node("root");
		foreach(string s in new[] {"Automotive Electronics",
			"Automotive Electronics---Body Electronics",
			"Automotive Electronics---Body Electronics---Access Control Systems",
			"Automotive Electronics---Body Electronics---Body Control Modules",
			"Automotive Electronics---Driver Information",
			"Automotive Electronics---Driver Information---Clocks",
			"Automotive Electronics---Driver Information---Compass Systems",
			"Automotive Electronics---HomeL",
			"Automotive Electronics---Infotainment & Connectivity",
			"Automotive Electronics---Infotainment & Connectivity---Handsfree Systems",
			"Automotive Interiors",
			"Automotive Interiors---Door Panels",
			"Automotive Interiors---Floor Consoles",
			"Automotive Interiors---Headliners & Overhead Systems",
			"Automotive Interiors---Overhead Consoles",
			"Automotive Seating",
			"Automotive Seating---Complete Seats",
			"Automotive Seating---Complete Seats---SuperThin Seats"})
		{
			AddNodes(rootNode, s.Split(new[] {"---"}, StringSplitOptions.RemoveEmptyEntries));
		}
		new JavaScriptSerializer().Serialize(rootNode.Nodes).Dump();
	}
	
	public void AddNodes( Node parentNode, string[] names)
	{
		if (names.Any())
		{
			var node = parentNode.AddNode(names.First());
			AddNodes(node, names.Skip(1).ToArray());
		}
	}
	
	public class Node
	{
		public Node(string name)
		{
			Name = name;
			Nodes = new List<Node>();
		}
		
		public Node AddNode(string name)
		{
			if (!this.Nodes.Select(n => n.Name).Contains(name.Trim()))
			{
				//name.Dump(this.Name);
				this.Nodes.Add(new Node(name.Trim()));
			}
			return this.Nodes.Where (n => n.Name == name).First();
		}
		
		public string Name { get;set;}
		public List<Node> Nodes { get; set; }
	}
