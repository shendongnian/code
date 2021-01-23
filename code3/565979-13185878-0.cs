    public class Base
    {
        public virtual void Say()
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class A : Base
    {
        public new void Say()
        {
            Console.WriteLine("42");
        }
    }
    public class B : Base
    {
        public override void Say()
        {
            Console.WriteLine("Goodbye, Cruel World!");
        }
    }
