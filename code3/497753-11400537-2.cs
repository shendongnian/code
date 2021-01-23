    public abstract class A
    {
        public abstract void DoStuff();
    }
    
    public abstract class B : A
    {
        // Empty
    }
    
    public class C : B
    {
        public override void DoStuff()
        {
            Console.WriteLine("hi");
        }
    }
