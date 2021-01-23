    public abstract class AbstractFunctionality:IFunctionality
    {
        public virtual void Method()
        {
            Console.WriteLine("Abstract stuff" + "\n");
        }       
    }
    
    public class ConreteFunctionality:AbstractFunctionality
    {
        public override void Method()
        {
            Console.WriteLine("Concrete stuff" + "\n");
        }
    }
