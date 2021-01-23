    class Program
    {
       
        static void Main(string[] args)
        {
            TestPointer test = new TestPointer();
            test.function1();
        }
    }
    class TestPointer
    {
        private delegate void fPointer(); // point to every functions that it has void as return value and with no input parameter
        public void function1()
        {
            fPointer point = new fPointer(function2);
            point();
        }
        private void function2()
        {
            Console.WriteLine("Bla");
        }
    }
