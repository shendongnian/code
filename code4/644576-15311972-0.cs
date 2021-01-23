    using System;
    
    public interface IBase
    {
        void Process();
    }
    
    public interface IDerived : IBase
    {
        new void Process();
    }
    
    public class FunkyImpl : IDerived
    {
        void IBase.Process()
        {
            Console.WriteLine("IBase.Process");
        }
        
        void IDerived.Process()
        {
            Console.WriteLine("IDerived.Process");
        }
    }
    
    class Test
    {
        static void Main()
        {
            var funky = new FunkyImpl();
            IBase b = funky;
            IDerived d = funky;
            b.Process();
            d.Process();
        }
    }
