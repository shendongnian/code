    public class FooWrapper :Wrapper<IFoo>, IFoo
    {
        public FooWrapper(IFoo foo)
            : base(foo)
        {
        }
        public int Bar()
        {
            base.Precall(); return base._instance.Bar(); base.Postcall();
        }
        public int Bar2()
        {
            base.Precall(); return base._instance.Bar2(); base.Postcall();
        }
        public void VBar()
        {
            base.Precall();  base._instance.VBar(); base.Postcall();
        }
    }
