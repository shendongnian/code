    public class MyClass
    {
        public virtual IList<Foo> Foos { get; private set; }
      
        public MyClass()
        {
            foos = new MyList<Foo>();
        }
    }
