    public class Bar : IBar
    {
        public Bar(IFoo foo)
        {
            MyFoo = foo;
        }
    
        public virtual IFoo MyFoo { get; private set; }
    }
