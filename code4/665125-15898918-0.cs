    public class MyClass
    {
        public MyClass(): this(new MyThing())
        {
        }
        protected MyClass(MyThing thing)
        {
            Contract.Requires(thing != null);
            this.MyThing = thing;
        }
        public MyThing MyThing { get; set; }
    }
    public class MySpecialClass : MyClass
    {
        public MySpecialClass(): base(new MySpecialThing())
        {
        }
    }
