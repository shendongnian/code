    using System;
    class P
    {
      static void Main()
      {
          Func<double, Func<double, double>> powerFunctionGenerator = 
              baseNumber => exponent => Math.Pow(baseNumber, exponent);  
          Func<double, double> powerOfTwo = powerFunctionGenerator(2.0);
          Func<double, double> powerOfThree = powerFunctionGenerator(3.0);
          double power2 = powerOfTwo(10.0); 
          double power3 = powerOfThree(10.0);
          Console.WriteLine(power2); 
          Console.WriteLine(power3);
      }
    }
