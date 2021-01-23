    using System;
    interface IFoo { void Bar(); void Baz(); }
    class Alpha : IFoo
    { 
        void IFoo.Bar() 
        {
            Console.WriteLine("Alpha.Bar");
        }
        void IFoo.Baz()
        {
            Console.WriteLine("Alpha.Baz");
        }
    }
    class Bravo : Alpha
    {
        public void Baz()
        {
            Console.WriteLine("Bravo.Baz");
        }
    }
    class CharlieOne : Bravo
    {
        public void Bar() 
        {
            Console.WriteLine("CharlieOne.Bar");
        }
    }
    class CharlieTwo : Bravo, IFoo
    {
        public void Bar() 
        {
            Console.WriteLine("CharlieTwo.Bar");
        }
    } 
    class Program
    {
        static void Main()
        {
            IFoo foo = new Alpha();
            foo.Bar();
            foo.Baz();
            foo = new Bravo();
            foo.Bar();
            foo.Baz();
            foo = new CharlieOne();
            foo.Bar();
            foo.Baz();
            foo = new CharlieTwo();
            foo.Bar();
            foo.Baz();
         }
    }
