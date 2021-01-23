     public class Base
        {
            // Protected to ensure that only the derived class can access the _panel attribute
            private Panel _panel;
            public Base(Panel panel1)
            {
                _panel = panel1;
            }
    
            protected Panel Panel
            {  get { return _panel; } } 
        }
        
        public class Derived : Base
        {
            public Derived() : base(new Panel())
            {
                // refer this way: base.Panel (can only get)
            }
        }
