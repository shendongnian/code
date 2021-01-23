    public class MyDynamicClass : MarshalByRefObject, IMyBaseInterface
    {
        public void DoStuff()
        {
            Console.WriteLine("Hello other app domain!");
        }
    }
 
