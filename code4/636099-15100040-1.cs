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
            var x = new MyClass(); // object created
            x = null; // object may be eliglible for garbage collection now
            // theoretically, a GC could happen here, but probably not, with this little memory used
            System.Threading.Thread.Sleep(5000);
            // so we force a GC. Now all eligible objects will definitely be collected
            GC.Collect(2,GCCollectionMode.Forced);
            //however their finalizers will execute in a separate thread, so we wait for them to finish
            GC.WaitForPendingFinalizers();
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("END");
        }
    }
