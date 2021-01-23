    using System;
    
    public interface IBase {}
    public interface IAdvanced : IBase {}
    
    public class Base : IBase {}
    public class Advanced : IAdvanced {}
    
    class Test
    {
        public static bool DoSomething<T>(T item) where T: IBase
        {
            return DoSomethingSpecific(item);
        }
        
        public static bool DoSomethingSpecific(IBase item)
        {
            return true;
        }
        
        public static bool DoSomethingSpecific(IAdvanced item)
        {
            return false;
        }
        
        static void Main()
        {
            Console.WriteLine(DoSomething(new Base()));     // True
            Console.WriteLine(DoSomething(new Advanced())); // True
        }    
    }
