    abstract class BaseClass
    {
        public abstract int Property { get; }
    }
    
    class Between : BaseClass
    {
        public override int Property
        {
            get { ... }
        }
    }
    
    class NewClass : Between
    {
        public new int Property
        {
            get { return base.Property; }
            set { ... }
        }
    }
