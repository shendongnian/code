    using System;
    using System.Text;
    
    namespace math
    {
        class Program
        {
            static void Main(string[] args)
            {
                //
                // Two values.
                //
                float value1 = 123.456F;
                float value2 = 123.987F;
                //
                // Take floors of these values.
                //
                float floor1 = (float)Math.Floor(value1);
                float floor2 = (float)Math.Floor(value2);
    
                //
                // Write first value and floor.
                //
                Console.WriteLine(value1);
                Console.WriteLine(floor1);
                //
                // Write second value and floor.
                //
                Console.WriteLine(value2);
                Console.WriteLine(floor2);
                return;        
            }
        }
    }
