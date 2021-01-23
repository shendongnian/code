    abstract class A
    {
        public abstract int X { get ; }
    }
    class B : A
    {
        public override int X { get { return 5 ; } }
    }
