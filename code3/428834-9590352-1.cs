    public class PolyTest
    {
        public void SomeMethod()
        {
            Console.WriteLine("Hello from base");
        }
    }
    public class PolyTestChild : PolyTest
    {
        new public void SomeMethod()
        {
            Console.WriteLine("Hello from child");
        }
    }
