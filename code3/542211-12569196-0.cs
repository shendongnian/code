    public class C
    {
        private readonly object _parent;
        public C(object parent)
        {
            _parent;
        }
    
        public void Do()
        {
            Type type = _parent != null ? _parent.GetType() : null;
            // Do something with type...
        }
    }
