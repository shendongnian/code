    public abstract class Node
    {
        public Folder Parent { get; set; }
        public string Name { get; set; }
        public abstract long Size { get; }
    }
    
    public class File : Node
    {        
        private long _size;
    
        public override long Size
        {
            get { return _size; }
        }
    
        public void AddTo(Folder folder)
        {
            folder.Add(this);
        }
    
        public void RemoveFrom(Folder folder)
        {
            folder.Remove(this);
        }
    }
    
    public class Folder : Node
    {
        private List<Node> _children = new List<Node>();
    
        public void Add(Node node)
        {
            if (node.Parent == this)
                return; // already a child of this folder
    
            _children.Add(node);
            node.Parent = this;
        }
    
        public void Remove(Node node)
        {
            if (node.Parent != this)
                return; // not a child of this folder
    
            _children.Remove(node);
            node.Parent = null;
        }
    
        public override long Size
        {
            get { return _children.Sum(node => node.Size); }
        }
    }
