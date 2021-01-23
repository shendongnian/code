    class Program
    {
        static void Main(string[] args)
        {
            SomeClass someInstance = new SomeClass();
            string name = Console.ReadLine();
            someInstance.Call("SayHello", name);
        }
    }
    class SomeClass
    {
        public void SayHello(string name)
        {
            Console.WriteLine(String.Format("Hello, {0}!", name));
        }
        public void Call(string methodName, params object[] args)
        {
            this.GetType().GetMethod(methodName).Invoke(this, args);
        }
    }
