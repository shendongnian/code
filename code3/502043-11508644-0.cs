    using System;
    
    namespace ConsoleApplication3
    {
    class Program
    {
        static void Main(string[] args)
        {
            var x = new Thing(5);
            var y = new Child(x);
        }
    }
    class Child : AbstractParent
    {
        public Child(Thing provided)
            : base()
        {
            parentthing = provided;
            base.Initialise();
        }
    }
    abstract class AbstractParent
    {
        protected Thing parentthing;
        public AbstractParent()
        {
            
        }
        private void AssertThingyNotNull()
        {
            if (parentthing == null) throw new Exception("Waaa");
        }
        public void Initialise()
        {
            AssertThingyNotNull();
        }
    }
    class Thing
    {
        private int i;
        public Thing(int i)
        {
            this.i = i;
        }
        public Thing Add(int b)
        {
            i += b;
            return new Thing(i);
        }
    }
}
