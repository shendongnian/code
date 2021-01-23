    public class Program
        {
            static void Main(string[] args)
            {
                var res = Test();
            }
            
            static bool Test()
            {
                var a = 5;
                var b = 6;
    
                return a.TrueOrAbort(b);
                
                
            }
    
        }
    
        public static class MyHelper
        {
            public static bool TrueOrAbort<T>(this T first, T second) where T : struct, IComparable  
            {
                if (first.Equals(second)) 
                    return true;
    
                Environment.Exit(0);
    
                return false;
            }
        }
