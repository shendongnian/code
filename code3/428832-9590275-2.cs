    public class Base
    {
        public void DoSomething()
        {
            Console.WriteLine("Base");
        }
    }
    public class Child : Base
    {
        public new void DoSomething()
        {
            Console.WriteLine("Child");
        }
    }
