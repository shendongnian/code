    public class PolyTest
    {
        public void SomeMethod()
        {
            Console.WriteLine("Hello from base");
        }
    }
    public class PolyTestChild : PolyTest
    {
        /// <summary>
        /// blah blah blah,  overrides the base implementation in PolyTest
        /// </summary>
        new public void SomeMethod()
        {
            Console.WriteLine("Hello from child");
        }
    }
