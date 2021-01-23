    delegate int Multiplication(int x, int y)
    public class Program
    {
       static void Main(String[] args)
       {
          Multiplication s = (o,p)=>o*p;
          int result = s(5,2);
          Console.WriteLine(result); // gives 10
       }
    }
