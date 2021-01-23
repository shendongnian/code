    public class M
    {
        public void Main(TypeA new_args1, TypeB new_args2)
        {
            var b = new B(new_args1, new_args2);
            var a = new A(b);
        }
    }
    public class A
    {
        private readonly B _b;
        public A(B b)
        {
            _b = _b;
        }
    }
    public class B
    {
        public B(TypeA new_args1, TypeB new_args2)
        {
        }
    }
