    public class Derived : Base
    {
        private Panel _panel;
    
        public Derived() : this(new Panel()) {}
    
        private Derived(Panel panel1) : base(panel1)
        {
            _panel = panel1;
        }
    }
