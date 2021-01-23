    public class Base
    {
        public Panel panel {get; set;};
        public Base(Panel panel1)
        {
             panel = panel1;
        }
    }
    public class Derived : Base
    {
        public Derived() : base(new Panel())
        {
              //  this.panel
        }
    }
