    public class Parent
    {
        private IList<Child> _children;
    
        public Parent()
        {
            _children = new List<Child>();
        }
    
        public virtual string Number { get; set; }
        public virtual IEnumerable<Child> Children { get { return _children; } }
    
        public virtual void AddChild(Child child)
        {
            _children.Add(child);
            child.Parent = this;
        }
    
        public virtual void RemoveChild(Child child)
        {
            _children.Remove(child);
            child.Parent = null;
        }
    }
    
    public class Child
    {
        public virtual string Number { get; set; }
        public virtual Parent Parent { get; set; }
    }
