    public class TreeService
    {
        private IEnumerable<INode> _relationships;
        private INode _rootNode;    
        public TreeService(INode rootNode, IEnumerable<INode> nodeRelationships)
        {
            _relationships = nodeRelationships;
            _rootNode = rootNode;
        }
        public Tree<INode> BuildTree()
        {
            Tree<INode> tree;
            tree = new Tree<INode>(_rootNode, _relationships);
            return tree;
        }
    }
