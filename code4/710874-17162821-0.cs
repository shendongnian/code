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
        public string SomeBaseProp { get; set; }
    }
    class Child : Parent
    {
        public Child()
        {
            Console.WriteLine(base.SomeBaseProp);
        }
        public int SomeChildProp { get; set; }
    }
