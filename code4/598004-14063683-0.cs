    public class Node
    {
        public Node(string name)
        {
            Name = name;
        }
        private List<Node> children = new List<Node>();
        public string Name { get; set; }
        public void Add(Node child)
        {
            children.Add(child);
        }
        public void Print(string prefix)
        {
            Console.WriteLine(prefix + Name);
            prefix = "-" + prefix;
            foreach (var child in children) child.Print(prefix);
        }
    }
    class Program
    {
        static Random  random = new Random();
        public static Node CreateBranch(int depth, int maxDepth, int maxWidth)
        {            
            if (depth > maxDepth) return null;
            var node = new Node(Path.GetRandomFileName());
            int width = random.Next(maxWidth);
            depth++;
            for (var i=0; i<width; i++)
            {
                var child = CreateBranch(depth, maxDepth, maxWidth);
                if (child != null) node.Add(child);
            }
            return node;
        }
        static void Main(string[] args)
        {
            var node = CreateBranch(0, 5, 5);
            node.Print("");
        }
    }
