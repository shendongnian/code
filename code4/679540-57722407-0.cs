	public class TreeNode {
		public string id { get; private set; }
		public string text { get; private set; }
		public bool selectable { get; private set; }
		public readonly Dictionary<string, TreeNode> nodes = new Dictionary<string, TreeNode>();
		[JsonIgnore]
		public TreeNode Parent { get; private set; }
		public TreeNode(
			string id,
			string text,
			bool selectable
		) {
			this.id = id;
			this.text = text;
			this.selectable = selectable;
		}
		public TreeNode GetChild(string id) {
			var child = this.nodes[id];
			return child;
		}
		public void Add(TreeNode item) {
			if(item.nodes != null) {
				item.nodes.Remove(item.id);
			}
			item.Parent = this;
			this.nodes.Add(item.id, item);
		}
	}
