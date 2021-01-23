    using System;
    
    [assembly: CLSCompliant(true)]
    
    public class Test<T>
    {
        public static void Expect(T arg)
        {
        }
    
        public static void Expect(ref T arg)
        {
        }
    
        public static void Main()
        {
        }
    }
