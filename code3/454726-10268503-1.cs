    public class BaseNode<T> where T : BaseNode<T>
    {
      private T _parent;
      public T Parent { get { return _parent;} }
    }
    public class Node : BaseNode<Node>
    {
    } 
    public class TreeNode : BaseNode<TreeNode>
    {
    }
