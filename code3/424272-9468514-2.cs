    public interface IBinaryTree<T>
    {
        void Build(IEnumerable<T> source);
        IBinaryNode<T> Root { get; set; }
    }
    
    public class BinaryTree<T> : IBinaryTree<T>
    {
        private readonly List<IBinaryNode<T>> nodes;
        private int nodeId = 0;
    
        public IBinaryNode<T> Root { get; set; }
    
        public BinaryTree()
        {
            nodes = new List<IBinaryNode<T>>();
        }
    
        public bool IsLeaf(IBinaryNode<T> binaryNode)
        {
            return (binaryNode.LeftChild == null && binaryNode.RightChild == null);
        }
    
        public void Build(IEnumerable<T> source)
        {
            foreach (var item in source)
            {
                var node = new BinaryNode<T>(item, nodeId);
                nodeId++;
                nodes.Add(node);
            }
    
            //construct a tree
            while (nodes.Count > 1) //while more than one node in a list
            {
                var taken = nodes.Take(2).ToList();
    
                // Create a parent BinaryNode and sum probabilities
                var parent = new BinaryNode<T>()
                {
                    LeftChild = taken[0],
                    RightChild = taken[1]
                };
    
                //this has been added so remove from the topmost list
                nodes.Remove(taken[0]);
                nodes.Remove(taken[1]);
                nodes.Add(parent);
            }
    
            Root = nodes.FirstOrDefault();
        }
    }
