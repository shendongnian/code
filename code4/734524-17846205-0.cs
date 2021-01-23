    using System;
    
    namespace GenericSqrt
    {
        class Program
        {
            static void Main(string[] args)
            {
                var array = new object[] { "2", null, 4.1f, 4.444D, "11.3", 0, "Text", new DateTime(1, 1, 1) };
    
                foreach (var value in array)
                {
                    try
                    {
                        Console.WriteLine(Sqrt(value));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                Console.ReadLine();
            }
    
            private static double Sqrt(object value)
            {
                double converterValue = Convert.ToDouble(value);
                return Math.Sqrt(converterValue);
            }
        }
    }
