    public class Base
    {
        public void DoSomething()
        {
            Console.WriteLine("Base");
    }
    public class Child : Base
    {
        public void new DoSomething()
        {
            Console.WriteLine("Child");
        }
    }
