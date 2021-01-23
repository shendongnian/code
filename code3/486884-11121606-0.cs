    class Base 
    {
        public virtual void A()
        {
            Console.WriteLine("Base::A");
        }
        public virtual void B()
        {
            Console.WriteLine("Base::B");
        }
    }
    
    class Derived : Base 
    {
        public override void A()
        {
            Console.WriteLine("Derived::A");
        }
        public new int B()
        {
            Console.WriteLine("Derived::B");
        }
    }
