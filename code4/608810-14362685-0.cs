    class Base
    {
        public Base()
        {
            Console.WriteLine("Base() called");
        }
        public Base(int x)
        {
            Console.WriteLine("Base(int x) called");
        }
    }
    class Sub : Base
    {
        public Sub()
        {
            Console.WriteLine("Sub() called");     
        }
    }
