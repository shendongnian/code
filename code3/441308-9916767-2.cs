    public abstract class Node
    {
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
    }
    
    public class Folder : Node
    {
        private List<Node> _children = new List<Node>();
    
        public void Add(Node node)
        {
            if (_children.Contains(node))
                return;
    
            _children.Add(node);
        }
    
        public void Remove(Node node)
        {
            if (!_children.Contains(node))
                return;
    
            _children.Remove(node);
        }        
    
        public override long Size
        {
            get { return _children.Sum(node => node.Size); }
        }
    }
