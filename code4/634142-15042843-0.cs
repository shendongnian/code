    public class ChildrenList : List<MyClass>
    {
        public MyClass Parent { get; private set; }
   
        public ChildrenList(MyClass parent) { this.Parent = parent; }
        public override void Add(MyClass item)
        {
            item.Parent = Parent;
            base.Add(item);
        }
    }
