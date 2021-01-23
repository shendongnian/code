    public class A
    {
        public A() { }
        public A(int x)
        {
            this.x = x;
        }
        protected int x;
    }
    public class B
    {
        public static A CreateClassA()
        {
            A x = new A(5);
            return x;
        }
    }
