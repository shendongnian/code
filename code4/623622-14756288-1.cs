    public class Derived : Base
    {
        private readonly string name;
        public Derived(string name) : base(name.Length)
        {
            this.name = name;
        }
        public Derived() : base(-1)
        {
            this.name = null;
        }
    }
