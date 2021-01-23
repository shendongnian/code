    abstract class A
    {
            public abstract int ReadOnlyProp {get;}
    }
    class B : A
    {
        public override int ReadOnlyProp
        {
            get { return 42; }
        }
    }
