    public class A
    {
        private readonly B _b;
        public A(TypeA args1, TypeB args2)
        {
            _b = new B(args1, args2);
        }
    }
    public class B
    {
        public B(TypeA new_args1, TypeB new_args2)
        {
        }
    }
