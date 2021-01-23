    public class A
    {
        public virtual int v { get { return 1; } }
    }
    public class B : A { }
    public class C : A
    {
        public override int v
        {
            get { return 2; } 
        }
    }
