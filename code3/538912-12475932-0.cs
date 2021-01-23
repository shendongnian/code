    using System;
    class Program
    {
        static void Main(string[] args)
        {
            TestPointer test = new TestPointer();
            test.function1(test.function2);   
        }
    }
    class TestPointer
    {
        public delegate void fPointer(); 
        public void function1(fPointer ftr)
        {
            ftr();
        }
        public void function2()
        {
            Console.WriteLine("Bla");
        }
    }
