    public class Base
    {
        private readonly int id;
        public Base(int id)
        {
            this.id = id;
        }
    }
    public class Derived : Base
    {
        public Derived(int id) : base(id)
        {
        }
    }
