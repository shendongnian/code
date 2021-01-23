    public abstract class B : A.InnerInterface
    {
        public abstract void Method();
    }
    
    public class C : B
    {
        public override void Method()
        {
            System.Console.WriteLine("C::A.InnerInterface.Method()");
        }
    }
