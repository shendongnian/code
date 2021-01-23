    public class MyClass
    {
        private static MyClass heldInstance;
        public MyClass()
        {
            heldInstance = this;
        }
        ~MyClass()
        {
            Console.WriteLine("Finalizer called");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var x = new MyClass();
            x = null;
            System.Threading.Thread.Sleep(1000);
            GC.Collect(2,GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            System.Threading.Thread.Sleep(20000);
            Console.WriteLine("END");
        }
    }
