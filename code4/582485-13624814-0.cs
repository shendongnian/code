    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplicationForTesting
    {
        delegate int Increment(int val);
        delegate bool IsEven(int v);
     class lambdaExpressions
    {
        static void Main(string[] args)
        {
          Increment Incr = count => count + 1;
          IsEven isEven = n => n % 2 == 0;
           Console.WriteLine("Use incr lambda expression:");
           int x = -10;
           while (x <= 0)
           {
               Console.Write(x + " ");
               bool result = isEven(x);
               Console.WriteLine(" is " + (result == true ? "even" : "odd"));
               x = Incr(x);
           }
