    class Base
    {
        private string name; 
        public string Name { get; set; }
        private string address; 
        public string Address { get; set; }
    }
    
    class Derived:Base
    {
        Derived(Base toCopy)
        {
            this.Name = toCopy.Name;
            this.Address = toCopy.Address;
        }
        private string field; 
        public String field { get; set; }
    }
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Base b = new Base();
                b.Address = "Iliff";
                b.Name = "somename"; 
    
                //You are now passing the base class into the constructor of the derived class.
                Derived d = new Derived(b);
    
            }
        }
    }
