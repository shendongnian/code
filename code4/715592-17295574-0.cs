    abstract class BaseClass
    {
        public int Property
        {
            get { ... }
        }
    }
    
    class NewClass : BaseClass
    {
        public new int Property
        {
            get { return base.Property; }
            set { ... }
        }
    }
