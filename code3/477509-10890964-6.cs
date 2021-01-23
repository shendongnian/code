    public class Node
    {
        private readonly IDictionary<string, Node> _nodes = 
            new Dictionary<string, Node>();
        public string Path { get; set; }
    }
