    interface IFoo
    {
        void Bar();
    }
    interface IBaz : IFoo
    {
        new void Bar();
    }
    interface Qux : IBaz
    {
    }
    class A : IQux // equivalent to class A : IQux, IBaz, IFoo (spec sec. 13.4.6)
    {
        void IFoo.Bar()
        {
            Console.WriteLine("IFoo.Bar");
        }
        void IBaz.Bar()
        {
            Console.WriteLine("IBaz.Bar");
        }
        public void Bar()
        {
            Console.WriteLine("A.Bar");
        }
        // Not allowed: void IQux.Bar() {...}
        // Since "The fully-qualified name of the interface member
        // must reference the interface in which the member
        // was declared" (s. 13.4.1)
    }
