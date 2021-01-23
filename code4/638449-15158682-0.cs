    public class A 
    {
        public virtual Int32 beingSupportedRate
        { 
            get { return 0; }
        }
    }
    public class B : A
    {
        public override Int32 beingSupportedRate 
        {
            get { return 1; }
        }
    }
