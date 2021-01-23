    public class Test
    {
        private readonly IFoo foo;
        public Test(IFoo foo)
        {
            this.foo = foo;
        }
        public void Condition()
        {
            if (x == y)
            {
               foo.MethodOne();
            }
            else
            {
                foo.MethodTwo();
            }
        }
    }
