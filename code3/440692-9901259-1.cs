     class Program
    {
        static void Method()
        {
            Console.WriteLine("Method");
        }
        static void Main(string[] args)
        {
            Action a = Method;
            MyClass.SomeMethod(a);
            MyClass.SomeMethod(Method);
            Console.ReadLine();
        }
    }
    class MyClass
    {
        public static void SomeMethod(Action del)
        {
            del();
        }
    }
