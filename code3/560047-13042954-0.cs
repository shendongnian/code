    I'm assuming this isn't a chicken egg problem. The Parent would be created first and therefore children would be added later. 
    public class Node
    {
        public List<Node> ChildNodes {get; private set;}
        public Node ParentNode {get; private set;}
    
        public Node():this(null)
        {
        }
    
        public Node(Node parentNode)
        {
            ParentNode = parentNode;
            ChildNodes = new List<Node>();
        }
    
        public void AddChildNode(Node childNode){
           childNode.ParentNode = this;
           ChildNodes.Add(childNode);
        }
    
    }
