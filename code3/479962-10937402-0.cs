    public class Parent
    {
        public override String ToString()
        {
            return ToStringPrivate();
        }
        private string ToStringPrivate()
        {
            return "in Parent";
        }
        public virtual void printer()
        {
            Console.WriteLine(this.ToStringPrivate());
        }
    }
    public class Child : Parent
    {
        public override String ToString()
        {
            return "in Derived";
        }
        public override void printer()
        {
            base.printer();
            Console.WriteLine(this.ToString());
        }
    }
