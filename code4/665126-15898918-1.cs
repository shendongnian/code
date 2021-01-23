    public class MyClass
    {
        private readonly MyThing myThing;
        public MyClass(): this(new MyThing())
        {
        }
        protected MyClass(MyThing thing)
        {
            Contract.Requires(thing != null);
            myThing = thing;
        }
        public MyThing MyThing { get { return myThing; } }
    }
    public class MySpecialClass : MyClass
    {
        public MySpecialClass(): base(new MySpecialThing())
        {
        }
    }
