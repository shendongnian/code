    public class PathNode {
        public readonly string Name;
        private readonly IDictionary<string, PathNode> _children;
        public PathNode(string name) {
            Name = name;
            _children = new Dictionary<string, PathNode>(StringComparer.InvariantCultureIgnoreCase);
        }
        public PathNode AddChild(string name) {
            PathNode child;
            if (_children.TryGetValue(name, out child)) {
                return child;
            }
            child = new PathNode(name);
            _children.Add(name, child);
            return child;
        }
        public void Traverse(Action<PathNode> action) {
            action(this);
            foreach (var pathNode in _children.OrderBy(kvp => kvp.Key)) {
                pathNode.Value.Traverse(action);
            }
        }
    }
