    public class ObjectB
    {
        public ObjectA Parent {get; private set;}
        public ObjectB(ObjectA parent)
        {
            this.Parent = parent;
        }
    }
    public class ObjectA
    {
        private ObjectB GetNewObjectB()
        {
             return new ObjectB(this);
        }
    }
