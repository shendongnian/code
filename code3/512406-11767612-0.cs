    public class Base
    {
        private string Test = "";
    
        public Base(string test)
        {
            Test = test;
        }
    }
    public class Derived : Base
    {
        public Derived(string test) : base(test) // - This will call public Base(string test)
        {
        }
    }
