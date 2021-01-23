    public class MyClass
    {
        public virtual IList<Foo> Foos { get; private set; }
      
        public MyClass()
        {
            Foos = new MyList<Foo>();
        }
    }
