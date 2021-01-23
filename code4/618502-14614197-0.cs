    using System;
    
    public class Test
    {
        static void Main(string[] args)
        {
            // Find the largest double less than 3
            long bits = BitConverter.DoubleToInt64Bits(3);
            double a = BitConverter.Int64BitsToDouble(bits - 1);
            double b = Math.Floor(a);
            // Print them using the default conversion to string...
            Console.WriteLine(a.ToString() + " " + b.ToString());
            // Now use round-trip formatting...
            Console.WriteLine(a.ToString("r") + " " + b.ToString("r"));
        }
    }
