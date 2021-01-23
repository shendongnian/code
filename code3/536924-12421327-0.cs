       delegate int Arithm(int x, int y);
    
    public class CSharpApp
    {
        static void Main()
        {
            DoOperation(10, 2, Multiply);
            DoOperation(10, 2, Divide);
        }
    
        static void DoOperation(int x, int y, Arithm del)
        {
            int z = del(x, y);
            Console.WriteLine(z);
        }
    
        static int Multiply(int x, int y)
        {
            return x * y;
        }
    
        static int Divide(int x, int y)
        {
            return x / y;
        }
    } 
