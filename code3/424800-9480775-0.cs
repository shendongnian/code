    public class MyClass
    {
        private Order order;
    
        public MyClass()
        {
            order = new Order();
        }
    
        public MyClass(string name)
            : this()  // either call the default constructor
        {
            // or initialize explicitely
            order = new Order();
        }
    
    }
