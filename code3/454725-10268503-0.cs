    public class BaseNode<T>
    {
      private T _parent;
      public T Parent { get { return _parent;} }
    }
    public class Node : BaseNode<Node>
    {
    } 
    public class TreeNode : Node<TreeNode>
    {
    }
