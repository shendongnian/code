    public class Base
    {
        public int Name { get; set; }
        public string Address { get; set; }
        
        public Base()
        { }
        public Base(Base toCopy)
        {
            this.Name = toCopy.Name;
            this.Address = toCopy.Address;
        }
    }
    public class Derived : Base
    {
        public String Field { get; set; }
        public Derived(Base toCopy)
            : base (toCopy)
        { }
        
        // if desired you'll need a parameterless constructor here to
        // so you can instantiate Derived w/o needing an instance of Base
        public Derived()
        { }
    }
