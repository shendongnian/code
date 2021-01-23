    public class DomainClass { /*...*/ }
    public class DomainTreeNode: TreeNode
    {
        public DomainClass Element { get; private set; }
        public DomainTreeNode(DomainClass element): base(element.Name)
        {
            Element = element;
            
            /* iterate on element's children and add them to the node's 
               Childs collection ...*/ 
        }
    }
