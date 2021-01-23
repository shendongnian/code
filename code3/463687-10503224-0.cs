    public abstract class MyBaseObject
    {
        public MyBaseObject(IEnumerable<MyBaseObject> parent)
        {
            this.Parent = parent;
        }
        public IEnumerable<MyBaseObject> Parent { get; set; }
    }
    public class MyRealObject : MyBaseObject
    { 
        public MyRealObject(MyRealCollection parent)
            : base(parent)
        { }
        public new MyRealCollection Parent { get { return (MyRealCollection)base.Parent; } }
    }
    public class MyRealCollection : IEnumerable<MyRealObject>
    { }
