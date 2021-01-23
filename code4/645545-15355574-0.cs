    module Functions {
        public Sum(a : int, b : int): int { a+b }
    }
    // or 
    class Functions2 {
        public static Mul(a : int, b : int): int { a*b }
    }
    using Functions;
    using Functions2;
    using System.Console;
    module Program
    {
      Main() : void
      {
        WriteLine(Sum(2, 3));
        WriteLine(Mul(4, 5));
      }
    }
