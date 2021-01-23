    abstract class Node { }
    enum BooleanOperator { And, Or }
    sealed class BooleanNode : Node
    {
        public BooleanOperator Operator { get; private set; }
        public Node Left { get; private set; }
        public Node Right { get; private set; }
        public BooleanNode(BooleanOperator op, Node left, Node right)
        {
            Operator = op;
            Left = left;
            Right = right;
        }
    }
    sealed class TagNode : Node
    {
        public string Tag { get; private set; }
        public TagNode(string tag) { Tag = tag; }
    }
