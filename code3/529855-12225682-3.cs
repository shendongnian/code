    public class Program
    {
        static void Main(string[] args)
        {
            NodeRef nodeRef = new NodeRef<MyNode>();
            var newNodeRef = (NodeRef<MyNode>) nodeRef;
        }
    }
