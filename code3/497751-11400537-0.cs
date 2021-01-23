    public abstract class A
    {
        public abstract void doStuff();
    }
    
    public abstract class B : A
    {
        //Empty
    }
    
    public class C : B
    {
        public override void doStuff()
        {
            Console.WriteLine("hi");
        }
    }
