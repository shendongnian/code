    public abstract class Node 
    {
        private Node parent;
        protected void SetParent(Node parent)
        {
            this.parent = parent;
        }
    }
    public class Folder : Node
    {
        void AddChild(Node child) 
        {
            this.children.Add(child);
            child.SetParent(this); // or, you could use a C# Property
        }
    }
    public class File : Node
    {
    }
