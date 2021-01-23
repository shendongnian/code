    public class Node
    {
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }
    }
    
    class OperatorNode : Node
    {
        public bool IsAnd { get; set; }
    }
    
    class QualificationNode : Node
    {
        public bool IsQualificationMet { get; set; }
    }
