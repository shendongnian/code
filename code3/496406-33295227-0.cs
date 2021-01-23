    public class Node
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Label { get; set; }
    
        public Node(int? parentId, int id, string label)
        {
            ParentId = parentId;
            Id = id;
            Label = label;
        }
    }
    
    public class TreeNode : List<TreeNode>
    {
        public string Key { get; set; }
        public string Label { get; set; }
    
    
        public IEnumerable<TreeNode> Descendants
        {
            get
            {
                yield return this;
    
                foreach (var child in this)
                {
                    foreach (var descendant in child.Descendants)
                    {
                        yield return descendant;
                    }
    
                }
            }
        }
    
        public TreeNode(string key, string label)
        {
            Key = key;
            Label = label;
        }
    
        public void CreateNode(int id, string label)
        {
            Add(new TreeNode(id.ToString(), label));
        }
    }
    
    public class Tree
    {
        private TreeNode _root = new TreeNode(null, null);
    
        public Tree(IEnumerable<Node> nodes)
        {
            nodes.ToList().ForEach(node => CreateNode(node.ParentId, node.Id, node.Label));
        }
    
        public void CreateNode(int? parentId, int id, string label)
        {
            if (parentId == null)
            {
                _root.CreateNode(id, label);
            }
            else
            {
                _root.Descendants.First(x => x.Key == parentId.ToString()).CreateNode(id, label);
            }
        }
    
        public IEnumerable<TreeNode> Descendants => _root.Descendants;
    }
