    public class MyClass
    {
        protected int param1;
        protected int param2;
        public void DoStuff()
        {
            Console.WriteLine(param1 + param2);
        }
    }
    public class MyClassLoader : MyClass
    {
        public MyClassLoader()
        {
            param1 = 1;
            param2 = 2;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClass myObj = new MyClassLoader();
            myObj.DoStuff();
            Console.WriteLine("Press any key to quit.");
            Console.ReadKey();
        }
    }
