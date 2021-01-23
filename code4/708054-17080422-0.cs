    public class MyClass
    {
        public MyClass(int x)
        {
            this.X = x;
        }
    
        public int X { get; private set; }
    
        public static implicit operator int(MyClass operand)
        {
            if (operand == null)
            {
                return 0;
            }    
            return operand.X;
        }
    }
         
    internal class Program
    {
        internal static void Main(string[] args)
        {
            MyClass x = null;
            int y = x; // What instance would a non-static operator use here?
        }
    }
