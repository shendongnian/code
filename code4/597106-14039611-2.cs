    public class Derived : Base
    {
        Panel aPanel;
        public Derived() : this(new Panel()) {}
        public Derived(Panel panel) : base(aPanel)
        {
            //Use aPanel Here.
        }
    }
