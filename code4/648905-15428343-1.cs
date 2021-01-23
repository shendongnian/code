    class TheBehavior
    {
        public void Act()
        {
            dynamic derived = this;
            try
            {
                derived.Foo(42);
                derived.Foob(43);
            }
            catch (RuntimeBinderException e)
            {
                Console.WriteLine("Method call failed: " + e.Message);
            }
        }
    }
    class TheDerived : TheBehavior
    {
        public void Foo(int bar)
        {
            Console.WriteLine("Bar: " + bar);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TheBehavior behavior = new TheDerived();
            behavior.Act();
            Console.ReadKey(true);
        }
    }
