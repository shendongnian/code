    class Program
        {
            static void Main(string[] args)
            {
                TestPointer test = new TestPointer();
                test.function1(() => test.function2());   // Error here: The name 'function2' does not exist in     current context
    
                Console.ReadLine();
            }
        }
    
        class TestPointer
        {
            private delegate void fPointer(); // point to every functions that it has void as return value and with no input parameter 
            public void function1(Action ftr)
            {
                ftr();
            }
    
            public void function2()
            {
                Console.WriteLine("Bla");
            }
        }
