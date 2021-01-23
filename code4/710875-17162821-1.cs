    class Program
    {
        static void Main(string[] args)
        {
            Parent p = new Child();
        }
    }
    class Parent
    {
        public Parent()
        {
            SomeBaseProp = "BaseProperty";
        }
        public Parent(string name)
        {
            SomeBaseProp = name;
        }
        public string SomeBaseProp { get; set; }
    }
    class Child : Parent
    {
        public Child()
        {
            Console.WriteLine(base.SomeBaseProp);
        }
        
        public Child(string someString) : base(someString)
        {  } //this will call the custom constructor of your base class before constructing this child class
        public int SomeChildProp { get; set; }
    }
