    public sealed class MyClass       
    { 
        int a; int b;    
        int Add (int x, int y)    
        {
            return x + y;
        }
    }
    public static class MyClassExtensions
    {
        public static decimal Average(this MyClass value,  int x, int y)
        {
            return (x + y)/2M;
        }
    }
